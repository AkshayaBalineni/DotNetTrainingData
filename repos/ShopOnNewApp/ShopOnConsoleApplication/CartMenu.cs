using ShopOnBussinessLayer.Implementation;
using ShopOnCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnConsoleApp
{
    public class CartMenu
    {
        private readonly CartManager cartManager = new CartManager();
        public void Main()
        {
            int ch;
            bool looping = true;
            while (looping)
            {
                Console.WriteLine("CART MENU");
                Console.WriteLine("****************************");
                Console.WriteLine("1.ADD PRODUCT TO CART");
                Console.WriteLine("2.DISPLAYING CART ITEMS");
                Console.WriteLine("3.Delete Product");
                Console.WriteLine("Enter your choice");
                Console.WriteLine("****************************");
                ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        AddItem(cartManager);
                        break;
                    case 2:
                        DisplaycartTotal(cartManager);
                        break;

                    default: looping = false; break;
                }
                Console.WriteLine("Do you want to continue in cart Menu? y/n");
                String s = Console.ReadLine();
                if (String.Equals(s, "N", StringComparison.OrdinalIgnoreCase))
                    looping = false;
            }

        }

        private void DisplaycartTotal(CartManager cartManager)
        {
            Tuple<int, double> info = cartManager.DisplaycartTotal();
            Console.WriteLine($"cart count = {info.Item1}");
            Console.WriteLine($"cart Total ={info.Item2}");
           
        }

        private void AddItem(CartManager cartManager)
        {
            Cart cart = new Cart();
            Console.WriteLine("Enter item name:");
            cart.Name = Console.ReadLine();
            Console.WriteLine("Enter item price:");
            cart.Price = Convert.ToDouble( Console.ReadLine());
            Console.WriteLine("Enter item Image URL:");
            cart.ImageUrl = Console.ReadLine();
            Console.WriteLine("Enter item QTY");
            cart.Qty = Convert.ToInt32 (Console.ReadLine());
            if (cartManager.AddItems(cart))
            {
                Console.WriteLine("item Saved");
            }
            else
                Console.WriteLine("item Not saved");

        }


    }
}
