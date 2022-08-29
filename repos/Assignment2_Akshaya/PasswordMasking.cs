using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_Akshaya
{
    class PasswordMasking
    {
        public void Main()
        {
            String userName=String.Empty, password=string.Empty ;
            Display(userName, password);
        }

        private void Display(String username, string password)
        {
            Console.WriteLine("Enter UserName: ");
            username = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            ConsoleKeyInfo key; 
            do
            {
                key = Console.ReadKey(true);
               // if (key.Key != ConsoleKey.Backspace)
                {
                   // Console.Write(false);
                    password += key.KeyChar;
                    Console.Write("*");
                }
            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine("*****************************");
            Console.WriteLine($"The username ={username}");
            Console.WriteLine($"The Password ={password}");

        }
    }

}
