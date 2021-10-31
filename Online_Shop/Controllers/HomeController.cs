using Online_Shop.Models;
using Online_Shop.Models.DTO;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using System;
using System.IO;
using System.Collections.Generic;

namespace Online_Shop.Controllers
{
    public class HomeController : BaseController
    {


        public ActionResult Index()
        {
            decimal total = 0;
            if ((User)Session["User"] != null)
            {
                List<ProductCart> list = (List<ProductCart>)Session[Convert.ToString(((User)Session["User"]).Id)];
                List<ProductCartItem> items = new List<ProductCartItem>();
                if (list != null)
                {
                    foreach (ProductCart i in list)
                    {
                        Product product = db.Products.Find(i.Id);
                        items.Add(new ProductCartItem()
                        {
                            Product = product,
                            Quantity = i.Quantity

                        });
                        total += product.Price * i.Quantity;
                    }

                }
            }
            Session["Total"] = total;

            //get new collection
            var products = db.Products.Where(p => p.Created_at.Year == DateTime.Now.Year).ToList().Take(8);
            return View(products);
        }
        public ActionResult MailUs()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin userLogin)
        {
            
            if (ModelState.IsValid)
            {
                User u = db.Users.FirstOrDefault(a => a.User_name == userLogin.user_name);
                
               if (u!=null)
                {
                    var flag = BCrypt.Net.BCrypt.Verify(userLogin.password, u.Password);
                    if (flag == true)
                    {
                        Session["user"] = u;
                        Session["Total"] =(decimal) 0;
                        Session["Message"] = "Logged in successfully";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("User_Name", "Incorrect account or password");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("User_Name", "Incorrect account or password");
                    return View();
                }
            }

            return View();
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserRoles userRoles, HttpPostedFileBase file)
        {
          
            if (ModelState.IsValid)
            {
                if (userRoles.User.User_name.Contains(' '))
                {
                    ModelState.AddModelError("User.User_name", "This name must have no space ");
                    return View();
                }
                if (db.Users.Any(m => m.User_name == userRoles.User.User_name))
                {
                    ModelState.AddModelError("User.User_name", "This name already existed in the Database ");
                    return View();
                }
                if (userRoles.User.Password == null)
                {
                    ModelState.AddModelError("User.Password", "The password is required");
                    return View();
                }

                if (db.Users.Any(m => m.Email == userRoles.User.Email))
                {
                    ModelState.AddModelError("User.Email", "This email already existed in the Database ");
                    return View();
                }
                if (db.Users.Any(m => m.Phone_number == userRoles.User.Phone_number))
                {
                    ModelState.AddModelError("User.Phone_number", "This phone number already existed in the Database ");
                    return View();
                }
                if (DateTime.Compare(userRoles.User.Dob, DateTime.Now) > 0)
                {
                    ModelState.AddModelError("User.Dob", "The date of birth is invalid");
                    return View();
                }
                if (file != null)
                {

                    string InputFileName = userRoles.User.Id + Path.GetFileName(file.FileName);
                    string ServerSavePath = Path.Combine(Server.MapPath("~/Include/Images/"), InputFileName);
                    file.SaveAs(ServerSavePath);

                    userRoles.User.Avatar = InputFileName;
                }
                else
                {
                    userRoles.User.Avatar = "";
                }
                userRoles.User.Password = BCrypt.Net.BCrypt.HashPassword(userRoles.User.Password);
                userRoles.User.RePassword = userRoles.User.Password;
                userRoles.User.Role_id = db.Roles.FirstOrDefault(r => r.Name.ToUpper().Equals("USER")).Id;
                db.Users.Add(userRoles.User);                
                db.SaveChanges();
                Session["Message"] =  "User Created Successfully";
                return RedirectToAction("Index");
            }
            userRoles.Roles = db.Roles.ToList();
            return View();
        }

        public ActionResult UpdatePassword()
        {
            if (System.Web.HttpContext.Current.Session["User"] == null)
                return RedirectToAction("Login", "Home");
            User user = (User)Session["User"];
            var password_User = new Password_User()
            {
                User_Id = user.Id,
                CurrentPassword = user.Password

            };
            return View(password_User);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePassword(Password_User pu)
        {
            if (System.Web.HttpContext.Current.Session["User"] == null)
                return RedirectToAction("Login", "Home");
            if (ModelState.IsValid)
            {
                if (!BCrypt.Net.BCrypt.Verify(pu.CurrentPasswordInput, pu.CurrentPassword))
                {
                    ModelState.AddModelError("CurrentPasswordInput", "Wrong current password!");
                    return View(pu);
                }else if(pu.CurrentPasswordInput.Equals(pu.NewPassword))
                {
                    ModelState.AddModelError("NewPassword", "The new password must be different from the old password!");
                    return View(pu);
                }
                User user = db.Users.Find(pu.User_Id);
                user.Password = BCrypt.Net.BCrypt.HashPassword(pu.NewPassword);
                user.RePassword = user.Password;
                db.Entry(db.Users.Find(pu.User_Id))
                    .CurrentValues.SetValues(user);
                db.SaveChanges();
                Session["Message"] = "Updated password successfully";
                return RedirectToAction("Index");
            }
            return View(pu);
        }

        public ActionResult UpdateProfile()
        {
            if (System.Web.HttpContext.Current.Session["User"] == null)
                return RedirectToAction("Login", "Home");
            User user = (User)Session["User"];
            user.RePassword = user.Password;
            return View((User)Session["User"]);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProfile(User user, HttpPostedFileBase file)
        {
            if (System.Web.HttpContext.Current.Session["User"] == null)
                return RedirectToAction("Login", "Home");
            if (ModelState.IsValid)
            {
                if (DateTime.Compare(user.Dob, DateTime.Now) > 0)
                {
                    ModelState.AddModelError("Dob", "The date of birth is invalid");
                   
                    return View(user);
                }
                if (db.Users.Any(m => m.Email == user.Email && m.Id != user.Id))
                {
                    ModelState.AddModelError("Email", "This email already existed in the Database ");
                   
                    return View(user);
                }
                if (db.Users.Any(m => m.Phone_number == user.Phone_number && m.Id != user.Id))
                {
                    ModelState.AddModelError("Phone_number", "This phone number already existed in the Database ");
                   
                    return View(user);
                }
                if (db.Users.Any(m => m.User_name == user.User_name && m.Id != user.Id))
                {
                    ModelState.AddModelError("User_name", "This user name already existed in the Database");
                    
                    return View(user);
                };
                User user1 = db.Users.Find(user.Id);
                    user1.RePassword = user.Password;
                    if (file != null)
                    {
                        if (user.Avatar != "")
                        {
                            System.IO.File.Delete(Path.Combine(Server.MapPath("~/Include/Images"), user.Avatar));
                        }


                        string InputFileName = Path.GetFileName(file.FileName);
                        string ServerSavePath = Path.Combine(Server.MapPath("~/Include/Images/"), InputFileName);
                        file.SaveAs(ServerSavePath);

                        user.Avatar = InputFileName;

                    }
                    else
                    {
                        user.Avatar = user1.Avatar;
                    }

                    user.Password = user1.Password;
                    user.RePassword = user.Password;
                    db.Entry(user1)
                        .CurrentValues.SetValues(user);
                    db.SaveChanges();
                    Session["Message"] = "Updated profile successfully";
                Session["User"] = db.Users.Find(user.Id);
                    return RedirectToAction("Index");
                
            }
            return View(user);
        }
        public ActionResult Logout()
        {
            if (System.Web.HttpContext.Current.Session["User"] == null)
                return RedirectToAction("Login", "Home");
           
            Session.Remove("User");
            Session.Remove("Total");
            Session["Message"] = "Logged out successfully";
            return RedirectToAction("Index");
        }
    }
}