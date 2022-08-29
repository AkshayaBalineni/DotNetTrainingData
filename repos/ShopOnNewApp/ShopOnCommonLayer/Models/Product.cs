using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnCommonLayer.Models
{
   public class Product :IComparable<Product>
    {
        public Company company;

        public int PId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int CompanyId { get; set; }
        public int CategoryId { get; set; }
        public Company Company { get; set; }
        public Category Category { get; set; }
        public char AvailableStatus { get; set; }
        public string ImageUrl { get; set; }
        public int IsDeleted { get; set; }
        public int CompareTo(Product other)
        {
            return this.PId.CompareTo(other.PId);
        }
    }
}
