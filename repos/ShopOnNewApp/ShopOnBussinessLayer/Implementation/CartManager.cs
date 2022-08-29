using ShopOnCommonLayer.Models;
using ShopOnDataLayer.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnBussinessLayer.Implementation
{
    public class CartManager
    {
        CartRepo cartRepo = new CartRepo();

        public Tuple<int, double> DisplaycartTotal()
        {
            Tuple<int, double> info = cartRepo.GetCartTotal();
            return info;

        }

        public bool AddItems(Cart cart)
        {
            return cartRepo.AddItem(cart);
        }
    }
}
