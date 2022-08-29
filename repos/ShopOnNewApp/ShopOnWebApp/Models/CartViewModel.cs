using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnWebApp.Models
{
    public class CartViewModel
    {
        public int PId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public string ImageUrl { get; set; }
        public double Amount { get; set; }
    }
}
