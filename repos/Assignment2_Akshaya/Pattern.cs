using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_Akshaya
{
    class Pattern
    {
        public void Main()
        {
            Console.WriteLine("Enter a positive number:");
            int n = Convert.ToInt32(Console.ReadLine());
            Pattern1(n);
            Pattern2(n);
            Pattern3(n);
            Pattern4(n);
            pattern5(n);
        }


        private void Pattern1(int n)
        {
            Console.WriteLine("Pattern1");
            Console.WriteLine("-----------------------");
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                    Console.Write("* ");
                Console.WriteLine();
            }
               
        }
        private void Pattern2(int n)
        {
            Console.WriteLine("Pattern2");
            Console.WriteLine("--------------------------");
            for (int i = n; i > 0; i--)
            {
                for (int j = 1; j <= i; j++)
                    Console.Write("* ");
                Console.WriteLine();
            }

        }
        private void Pattern3(int n)
        {
            Console.WriteLine("Pattern3");
            Console.WriteLine("-----------------------");
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                    Console.Write("* ");
                Console.WriteLine();
            }
        }
        private void Pattern4(int n)
        {
            Console.WriteLine("Pattern4");
            Console.WriteLine("-----------------------");
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n-i; j++)
                    Console.Write(" ");
                for (int k = 1; k <= i; k++)
                    Console.Write("*");
                Console.WriteLine();
            }

        }
        private void pattern5(int n)
        {
            Console.WriteLine("Pattern5");
            Console.WriteLine("-----------------------");
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n - i; j++)
                    Console.Write(" ");
                for (int k = 1; k <= i; k++)
                    Console.Write("* ");
                Console.WriteLine();
            }

        }
    }
}
