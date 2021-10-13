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
                if (files[0] != null)
                {
                    pc.Product.Images = "";
                    foreach (HttpPostedFileBase file in files)
                    {
                        //Checking file is available to save.  
                        if (file != null)
                        {
                            string InputFileName = Path.GetFileName(file.FileName);
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
                ViewBag.Message = "Created successfully!";
                ViewBag.Status = "Created New Product Successfully!";
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
                Product updatedProduct = db.Products.Find(pc.Product.Id);
                if (files[0] != null)
                {
                    // delete current images to add new images
                    string[] imageList = updatedProduct.Images.Split(';');
                    for (int i = 0; i < imageList.Length - 1; i++)
                    {
                        System.IO.File.Delete(imageList[i]);
                    }
                    // add new images
                    pc.Product.Images = "";
                    foreach (HttpPostedFileBase file in files)
                    {
                        //Checking file is available to save.  
                        if (file != null)
                        {
                            string ServerSavePath = Path.Combine(Server.MapPath("~/Include/Images") + Path.GetFileName(file.FileName));
                            //Save file to server folder  
                            file.SaveAs(ServerSavePath);
                            pc.Product.Images += Path.GetFileName(file.FileName) + ";";
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
                ViewBag.Status = "Updated Product Successfully!";
                return RedirectToAction("Index");
            }
            pc.Categories = db.Categories.ToList();
            return View(pc);
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