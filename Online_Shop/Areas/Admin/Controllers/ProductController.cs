
using Online_Shop.Models;
using Online_Shop.Models.DTO;
using PagedList;
using System;
using System.Collections.Generic;
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
            var list = (List < ProductWithCheckSpec >)TempData["Products"];
            if(list != null && page != null)
            {
                TempData["Products"] = list;
                return View(list.ToPagedList(page ?? 1, 10));
            }
            List <Product> productList = db.Products.ToList();
            List<ProductWithCheckSpec> productsWithCheckSpec = new List<ProductWithCheckSpec>();
            foreach (Product item in productList)
            {
                productsWithCheckSpec.Add(new ProductWithCheckSpec()
                {
                    Product = item,
                    CheckSpec = (db.Specs.FirstOrDefault(s => s.Product_id == item.Id) != null)
                });
            }
            var products = (from p in productsWithCheckSpec select p).OrderBy(a => a.Product.Id).ToList();
           
            return View(products.ToPagedList(page ?? 1, 10));
        }
        [HttpPost]

        public ActionResult Index(int? page, string searchString)
        {
            List<Product> productList = db.Products.ToList();
            List<ProductWithCheckSpec> productsWithCheckSpec = new List<ProductWithCheckSpec>();
            foreach (Product item in productList)
            {
                productsWithCheckSpec.Add(new ProductWithCheckSpec()
                {
                    Product = item,
                    CheckSpec = (db.Specs.FirstOrDefault(s => s.Product_id == item.Id) != null)
                });
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                var products = (from p in productsWithCheckSpec.Where(a => a.Product.Name.Contains(searchString) ||
                                  a.Product.Price.ToString().Contains(searchString) ||
                                  a.Product.Short_desc.Contains(searchString) ||
                                  a.Product.Category.Name.Contains(searchString)
                                  )
                                                                     select p).OrderBy(a => a.Product.Id).ToList();
                TempData["Products"] = products;
                return View(products.ToPagedList(page ?? 1, 10));
            }
            else
            {
                var products = (from p in productsWithCheckSpec select p).OrderBy(a => a.Product.Id).ToList();
                TempData["Products"] = products;
                return View(products.ToPagedList(page ?? 1, 10));
            }
        }

        public ActionResult Create()
        {
            return View(new ProductCategory() { Product = new Product(), Categories = db.Categories.ToList() });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCategory pc, HttpPostedFileBase[] files)
        {

            if (ModelState.IsValid)
            {
                if (db.Products.FirstOrDefault(a => a.Name == pc.Product.Name) != null)
                {
                    ModelState.AddModelError("Name", "This name already existed in the Database");
                    pc.Categories = db.Categories.ToList();
                    return View(pc);
                    
                }
                if (files[0] != null)
                {
                    pc.Product.Images = "";
                    foreach (HttpPostedFileBase file in files)
                    {
                        //Checking file is available to save.  
                        if (file != null)
                        {
                            string InputFileName = (db.Products.ToList().Count+1).ToString() + Path.GetFileName(file.FileName);
                            string ServerSavePath = Path.Combine(Server.MapPath("~/Include/Images/"), InputFileName);
                            //Save file to server folder  
                            file.SaveAs(ServerSavePath);
                            //System.IO.File.Delete(ServerSavePath);
                            pc.Product.Images += InputFileName + ";";
                        }
                    }
                }
                else
                {
                    ViewBag.UploadStatus = "Must choose an image!";
                    pc.Categories = db.Categories.ToList();
                    return View(pc);
                }
                pc.Product.Created_at = DateTime.Now;
                pc.Product.Updated_at = DateTime.Now;

                db.Products.Add(pc.Product);
                db.SaveChanges();

                Session["Message"] = "Product Created Successfully!";
                return RedirectToAction("Index");
            }
            pc.Categories = db.Categories.ToList();
            return View(pc);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            Product product = db.Products.Find(id);
            return View(new ProductCategory() { Product = product, Categories = db.Categories.ToList() });
        }
        //as
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductCategory pc, HttpPostedFileBase[] files)
        {
            if (ModelState.IsValid)
            {
                Product checkProduct = db.Products.FirstOrDefault(p => p.Name == pc.Product.Name);
                if (checkProduct == null || checkProduct.Id == pc.Product.Id)
                {
                    Product updatedProduct = db.Products.Find(pc.Product.Id);
                    if (files[0] != null)
                    {
                        // delete current images to add new images
                        string[] imageList = updatedProduct.Images.Split(';');
                        for (int i = 0; i < imageList.Length - 1; i++)
                        {
                            System.IO.File.Delete(Path.Combine(Server.MapPath("~/Include/Images"), imageList[i]));
                        }
                        // add new images
                        pc.Product.Images = "";
                        foreach (HttpPostedFileBase file in files)
                        {
                            //Checking file is available to save.  
                            if (file != null)
                            {
                                string InputFileName = pc.Product.Id.ToString() + Path.GetFileName(file.FileName);
                                string ServerSavePath = Path.Combine(Server.MapPath("~/Include/Images"), InputFileName);
                                //Save file to server folder  
                                file.SaveAs(ServerSavePath);
                                pc.Product.Images += InputFileName + ";";
                            }

                        }
                    }
                    else
                    {
                        pc.Product.Images = updatedProduct.Images;
                    }
                    Product a = pc.Product;
                    pc.Product.Updated_at = DateTime.Now;

                    db.Entry(updatedProduct)
                      .CurrentValues
                      .SetValues(pc.Product);
                    db.SaveChanges();
                    Session["Message"] = "Product Updated Successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Product.Name", "This name already existed in the Database");
                    pc.Categories = db.Categories.ToList();
                    return View(pc);
                }


            }
            pc.Categories = db.Categories.ToList();
            return View(pc);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            // delete images
            string[] imageList = product.Images.Split(';');
            for (int i = 0; i < imageList.Length - 1; i++)
            {
                System.IO.File.Delete(Path.Combine(Server.MapPath("~/Include/Images"), imageList[i]));
            }
            // delete product
            db.Products.Remove(product);
            db.SaveChanges();
            Session["Message"] = "Product Deleted Successfully!";
            return RedirectToAction("Index");
            //return Json(new { success = true, message = "Deleted" }, JsonRequestBehavior.AllowGet);
        }
    }
}