using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Shop.Models.DTO
{
    public class ProductCart
    {
        [Required]
        public int id { get; set; }

        [Required]
        public int quantity { get; set; }

    }
}