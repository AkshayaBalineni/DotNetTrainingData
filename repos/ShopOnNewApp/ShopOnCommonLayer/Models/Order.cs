using System;
using System.Collections.Generic;

namespace ShopOnCommonLayer.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public string OrderStatus { get; set; }
        public double TotalAmount { get; set; }
        public string AspCustomerId { get; set; }

        private List<OrderItem> orderItems = new List<OrderItem>();
        public void AddOrderItem (OrderItem orderItem)
        {
            this.orderItems.Add(orderItem);
        }
        public IEnumerable<OrderItem> GetOrderItems()
        {
            return this.orderItems;
        }
        public double GetOrderTotal()
        {
            double total = 0;
           foreach(var orderItem in this.orderItems)
            {
                total += orderItem.GetOrderItemTotal();
            }
            return total;
        }


    }
}