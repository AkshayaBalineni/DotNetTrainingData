using ShopOnBussinessLayer.Contracts;
using ShopOnBussinessLayer.Implementation;
using ShopOnCommonLayer.Models;
using ShopOnDataLayer.Contracts;
using ShopOnDataLayer.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnConsoleApplication
{
    public class OrderMenu
    {
        public void Main()
        {
            IOrderRepo orderRepo = new OrderRepoDBImpl();
            IOrderManager orderManager = new OrderManager(orderRepo);
            int ch;
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Order Menu");
                Console.WriteLine("***************************");
                Console.WriteLine("1.Add Order");
                Console.WriteLine("2.Display Order");
                Console.WriteLine("3.GetCustomerOrder");
                Console.WriteLine("4.GetOrder");
              
                Console.WriteLine("Enter your choice:");


                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        AddOrder(orderManager);
                        break;
                    case 2:
                        DisplayOrders(orderManager);
                        break;
                    case 3:
                        GetCustomerOrder(orderManager);
                        break;
                    case 4: GetOrder(orderManager);
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        break;
                }
                Console.WriteLine("Do you want to continue in product menu? y/n");
                String s = Console.ReadLine();
                if (String.Equals(s, "N", StringComparison.OrdinalIgnoreCase))
                    loop = false;
            }

        }
        private void GetOrder(IOrderManager orderManager)
        {
            Console.WriteLine("Enter the orderId:");
            int orderId = Convert.ToInt32(Console.ReadLine());
            Order order = orderManager.GetOrder(orderId);
            Console.WriteLine("OrderId\tOrderStatus\tOrderDate\tTotalAmount\tCustomerId");
            
            Console.WriteLine($"{order.OrderId}\t{order.OrderStatus}\t{order.OrderDate}\t{order.TotalAmount}");
        }
        private void GetCustomerOrder(IOrderManager orderManager)
        {
            Console.WriteLine("Enter the customerId:");
            int custId = Convert.ToInt32(Console.ReadLine());
            var orders = orderManager.GetCustomerOrder(custId).ToList();
            DisplayInfo(orders);
        }
        private void DisplayOrders(IOrderManager orderManager)
        {
            var orders = orderManager.GetOrders().ToList();
            DisplayInfo(orders);
        }
        private void DisplayInfo(List<Order> orders)
        {
            Console.WriteLine("OrderId\tOrderStatus\tOrderDate\tTotalAmount\tCustomerId");
            foreach (var order in orders)
            {
                Console.WriteLine($"{order.OrderId}\t{order.OrderStatus}\t{order.OrderDate}\t{order.TotalAmount}");
            }
        }
        private void AddOrder(IOrderManager orderManager)
        {
            Order order = new Order();
            Console.WriteLine("Enter customerID :");
            order.CustomerId = Convert.ToInt32(Console.ReadLine());
            order.OrderDate = DateTime.UtcNow;
            order.TotalAmount = 0;
            OrderItem orderItem1 = new OrderItem()
            {
                Product = new Product()
                {
                    PId = 2
                },
                ProductQty = 1
            };
            OrderItem orderItem2 = new OrderItem()
            {
                Product = new Product()
                {
                    PId = 5
                },
                ProductQty = 2
            };
            order.AddOrderItem(orderItem1);
            order.AddOrderItem(orderItem2);
            orderManager.AddOrder(order);
            if (order.OrderId == 0)
            {
                Console.WriteLine("Order not added");
            }
            else
            {
                Console.WriteLine($"Order added with orderId ={order.OrderId},ordertotal={order.TotalAmount}");
            }
        }
    }

}
