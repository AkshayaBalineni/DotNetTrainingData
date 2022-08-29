using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnCommonLayer.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMobileNumber { get; set; }

        public Company Company { get; set; }

        private List<Order> orders = new List<Order>();

        public void  AddOrders(Order order)
        {
            this.orders.Add(order);
        }
        public IEnumerable<Order> GetOrders()
        {
            return this.orders; 
        }

        public virtual double GetCustomerTotal()
        {
            double total = 0;
            foreach(var order in this.orders)
            {
                total += order.GetOrderTotal();
            }
            return total;
        }
    }
}
