using ShopOnBussinessLayer.Contracts;
using ShopOnCommonLayer.Models;
using ShopOnDataLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnBussinessLayer.Implementation
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepo orderRepository;
        public OrderManager(IOrderRepo orderRepo)
        {
            this.orderRepository = orderRepo;
        }
        public Order AddOrder(Order order)
        {
            return orderRepository.AddOrder(order);
        }

        public IEnumerable<Order> GetCustomerOrder(int customerId)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrders()
        {
            return orderRepository.GetOrders();
        }
    }
}
