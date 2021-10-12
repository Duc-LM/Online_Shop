using Online_Shop.Controllers;
using Online_Shop.Models;
using Online_Shop.Models.DTO;
using PagedList;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Shop.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(int? page)
        {
            IPagedList<Product> products = db.Products.ToList()
                                          .ToPagedList(page ?? 1, 10);
            return View(products);
        }
        [HttpPost]

        public ActionResult Index(int? page, string option, string search)
        {
            IPagedList<Product> products = null;
            switch (option)
            {
                case "Name":
                    products = db.Products.Where(p => p.Name == search).ToPagedList(page ?? 1, 10);
                    if (products == null)
                    {
                        ViewBag.Message = "No Result!";
                    }

                    break;
                case "Id":
                    products = db.Products.Where(p => p.Id.ToString() == search).ToPagedList(page ?? 1, 10);
                    if (products == null)
                    {
                        ViewBag.Message = "No Result!";
                    }

                    break;


                    break;
                default:
                    products = db.Products.ToList().ToPagedList(page ?? 1, 10);
                    break;

            }
            return View(products);
        }

        public ActionResult Create()
        {
            return View(new ProductCategory() { Product = new Product(), Categories = db.Categories.ToList() });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCategory pc, HttpPostedFileBase[] files)
        {
            Product p = pc.Product;
            if (ModelState.IsValid)
            {
                foreach (HttpPostedFileBase file in files)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        string ServerSavePath = Path.Combine(Server.MapPath("~/Include/Images/") + Path.GetFileName(file.FileName));
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                        pc.Product.Images += ServerSavePath + ";";
                    }

                }
                pc.Product.Created_at = DateTime.Now;
                pc.Product.Updated_at = DateTime.Now;

                db.Products.Add(pc.Product);
                db.SaveChanges();
                ViewBag.Message = "Created successfully!";
                return RedirectToAction("Index");
            }
            pc.Categories = db.Categories.ToList();
            return View(pc);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Product product = db.Products.Find(id);

            return View(new ProductCategory() { Product = product, Categories = db.Categories.ToList() });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductCategory pc, HttpPostedFileBase[] files)
        {
            if (ModelState.IsValid)
            {
                pc.Product.Images = "";
                foreach (HttpPostedFileBase file in files)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        string ServerSavePath = Path.Combine(Server.MapPath("~/Include/Images") + Path.GetFileName(file.FileName));
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                        pc.Product.Images += ServerSavePath + ";";
                    }

                }
                pc.Product.Updated_at = DateTime.Now;
                db.Entry(db.Products.Find(pc.Product.Id))
                  .CurrentValues
                  .SetValues(pc.Product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pc.Product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
            //return Json(new { success = true, message = "Deleted" }, JsonRequestBehavior.AllowGet);
        }
    }
}