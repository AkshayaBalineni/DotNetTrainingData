using ShopOnConsoleApplication;
using System;
namespace ShopOnConsoleApp
{
    class Program
    {
        static void Main()
        {
            int ch;
            bool looping = true;
            while (looping)
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("******************************");
                Console.WriteLine("1.Product Menu");
                Console.WriteLine("2.Cart Menu");
                Console.WriteLine("3.Customer Order Menu");
                Console.WriteLine("4.Order Menu");
                Console.WriteLine("5.Company Menu");
                Console.WriteLine("6.Bank Menu");
                Console.WriteLine("Enter your choice:");
                ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        new ProductMenu().Main();
                        break;
                    case 2:
                        //new CartMenu().Main();
                        break;
                    case 3:
                        //new CustomerOrder().Main();
                        break;
                    case 4: new OrderMenu().Main();
                        break;
                    case 6: new BankMenu().Main();
                        break;
                    default:
                        Console.WriteLine("Invalid entry");
                        break;
                }
                Console.WriteLine("Do you want to continue in Main Menu? y/n");
                String s = Console.ReadLine();
                if (String.Equals(s, "N", StringComparison.OrdinalIgnoreCase))
                    looping = false;
            }
        }
    }
}
