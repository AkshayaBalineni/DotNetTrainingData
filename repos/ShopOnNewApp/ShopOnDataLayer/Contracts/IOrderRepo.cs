using ShopOnCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnDataLayer.Contracts
{
    public interface IOrderRepo
    {
        Order AddOrder(Order order);
        Order GetOrder(int orderId);
        IEnumerable<Order> GetOrders();
        IEnumerable<Order> GetCustomerOrder(int customerId);
    }
}
