﻿using Online_Shop.Models;
using Online_Shop.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Online_Shop.Controllers
{
    public class ProductViewController : BaseController
    {
      

        public ActionResult Category(int ? id, int? page)
        {
            if(id== null)
            {
                return RedirectToAction("Index", "Home");
            }
            var products = db.Categories.Find(id).Products;
            TempData["Category_Id"] = id;
            return View(products.ToPagedList(page ?? 1, 9));
        }

        [HttpPost]
        public ActionResult Category(int? id,FormCollection form, int? page)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var products = db.Categories.Find(id).Products.ToList();

         
            TempData["Category_Id"] = id;
            switch (form["filter"])
            {
                case "increase":
                    products = db.Categories.Find(id).Products.OrderBy(p => p.Price).ToList();
                    break;
                case "decrease":
                    products = db.Categories.Find(id).Products.OrderByDescending(p => p.Price).ToList();
                    break;
              
            }
            return View(products.ToPagedList(page ?? 1, 9));
        }
        public ActionResult Manufacturer(string name,int? page)
        {
            List<Product> products = new List<Product>();
            if(string.IsNullOrEmpty(name) || !db.Specs.Any(s => s.Manufacturer == name))
            {
                products = db.Specs.Select(s => s.Product).ToList();
            }
            else
            {
                products = db.Specs.Where(s => s.Manufacturer == name).Select(s => s.Product).ToList();
            }
            TempData["Manufacturer_Name"] = name;
            return View(products.ToPagedList(page ?? 1, 9));
        }
        [HttpPost]
        public ActionResult Manufacturer(string name, FormCollection form, int? page)
        {
            List<Product> products = new List<Product>();
            if (string.IsNullOrEmpty(name) || !db.Specs.Any(s => s.Manufacturer == name))
            {
                products = db.Specs.Select(s => s.Product).ToList();
            }
            else
            {
                products = db.Specs.Where(s => s.Manufacturer == name).Select(s => s.Product).ToList();
                switch(form["filter"])
                {
                    case "increase":
                        products = db.Specs.Where(s => s.Manufacturer == name).Select(s => s.Product).ToList().OrderBy(p => p.Price).ToList();
                        break;
                    case "decrease":
                        products = db.Specs.Where(s => s.Manufacturer == name).Select(s => s.Product).ToList().OrderByDescending(p => p.Price).ToList();
                        break;
                }
            }
            TempData["Manufacturer_Name"] = name;
            return View(products.ToPagedList(page ?? 1, 9));
        }
        public ActionResult SingleItem(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var product = db.Products.Find(id);
            var spec = db.Specs.FirstOrDefault(s => s.Product_id == id);
            return View(new ProductSpec() { Product = product, Spec = spec });
        }
    }
}