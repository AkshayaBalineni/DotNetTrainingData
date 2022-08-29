using ShopOnCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ShopOnDataLayer.Implementation
{
    public class CartRepo
    {
        public ObservableCollection<Cart> cartItem = new ObservableCollection<Cart>();
        int count = 0;
        public bool AddItem(Cart cart)
        {
            
            bool isAdded = false;
            cartItem.Add(cart);
            ++count;
            isAdded = true;
            return isAdded;
            
        }
        /*public IEnumerable<Cart> GetCartItems()
        {
            return cartItem;
        }*/

        public Tuple<int, double> GetCartTotal()
        {
            double total = 0;
            foreach(var item in this.cartItem)
            {
                total += item.Price * item.Qty;

            }
            Tuple<int, double> info = Tuple.Create(count, total);
            return info;
        }
    }
}
