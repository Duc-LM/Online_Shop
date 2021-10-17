<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
=======
﻿using Online_Shop.Models;
using System.Collections.Generic;
using System.Linq;
>>>>>>> d153f9f992632ed9ae244d953d6b7ff7ed03d8fe

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
            return new ShopEntities().Specs.Select(m => m.Manufacturer).ToList();
        }
    }
}