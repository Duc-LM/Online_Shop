
using System.Collections.Generic;
using System.Linq;
﻿using Online_Shop.Models;

namespace Online_Shop.Utils
{
    public class NavHelper
    {
        public static List<Category> GetCategories()
        {
            return new ShopEntities().Categories.ToList();
        }
        public static List<string> GetManufacturers()
        {
            return new ShopEntities().Specs.Select(m => m.Manufacturer).Distinct().ToList();
        }
        public static List<Product> GetProducts()
        {
            return new ShopEntities().Products.ToList();
        }
    }
}