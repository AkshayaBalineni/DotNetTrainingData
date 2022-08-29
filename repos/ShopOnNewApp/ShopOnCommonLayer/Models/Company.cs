using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnCommonLayer.Models
{
   public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyStatus{ get; set; }
        private List<Product> products = new List<Product>();
        private List<Customer> customers = new List<Customer>();
        public bool IsDeleted { get; set; }
        public void AddProduct(Product product)
        {
            this.products.Add(product);
        }
        public IEnumerable<Product> GetProducts()
        {
            return this.products;
        }

        public void AddCustomer(Customer customer)
        {
            this.customers.Add(customer);
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return this.customers;
        }
    }
}
