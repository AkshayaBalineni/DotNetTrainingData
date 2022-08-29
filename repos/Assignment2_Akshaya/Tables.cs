using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_Akshaya
{
    class Tables
    {
        public void Main()
        {
            Console.WriteLine("Enter a Number:");
            int n = Convert.ToInt32(Console.ReadLine());
            DisplayTables(n);

        }

        private void DisplayTables(int n)
        {
            for(int i=1;i<=10;i++)
            {
                for (int j = 1; j <= n; j++)

                    Console.Write($"{j} * {i} = {i * j}\t");
                Console.WriteLine();
            }
           
        }
    }
}
