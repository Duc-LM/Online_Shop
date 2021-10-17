using Online_Shop.Controllers;
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
            return View(productsWithCheckSpec);
        }
        [HttpPost]

        public ActionResult Index(int? page, string option, string search)
        {
            IPagedList<Product> products = null;
            switch (option)
            {
                case "Name":
                    products = db.Products.Where(p => p.Name.Contains(search)).ToPagedList(page ?? 1, 10);
                    if (products == null)
                    {
                        TempData["Status"] = "No Result!";
                    }

                    break;
                case "Id":
                    products = db.Products.Where(p => p.Id.ToString() == search).ToPagedList(page ?? 1, 10);
                    if (products == null)
                    {
                        TempData["Status"] = "No Result!";
                    }

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

            if (ModelState.IsValid)
            {
                if (db.Products.FirstOrDefault(a => a.Name == pc.Product.Name) != null)
                {
                    ModelState.AddModelError("Name", "This name already existed in the Database");
                    return View();
                }
                if (files[0] != null)
                {
                    pc.Product.Images = "";
                    foreach (HttpPostedFileBase file in files)
                    {
                        //Checking file is available to save.  
                        if (file != null)
                        {
                            string InputFileName = pc.Product.Id.ToString() + Path.GetFileName(file.FileName);
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

                TempData["Status"] = "Created New Product Successfully!";
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
                    TempData["Status"] = "Updated Product Successfully!";
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
        [ValidateAntiForgeryToken]
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
            TempData["Status"] = "Deleted Product Successfully!";
            return RedirectToAction("Index");
            //return Json(new { success = true, message = "Deleted" }, JsonRequestBehavior.AllowGet);
        }
    }
}