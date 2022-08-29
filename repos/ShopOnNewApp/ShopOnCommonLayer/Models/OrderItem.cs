using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnCommonLayer.Models
{
    public class OrderItem
    {
        public int PId { get; set; }
        public Product Product { get; set; }
        public double Amount { get; set; }
        public int ProductQty { get; set; }

        public double GetOrderItemTotal()
        {
            return Product.ProductPrice * ProductQty;
        }
    }
}
