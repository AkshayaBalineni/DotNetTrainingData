using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_Akshaya
{
    class FactorsOf1_3_7
    {
        public void Main()
        {
            Console.WriteLine("Enter a Positive Number:");
            int n = Convert.ToInt32 (Console.ReadLine());
            Factors(n);
        }

        private void Factors(int n)
        {
            Console.WriteLine("The numbers that are divisible by 1, 3, 7 :");
            for(int i=1;i<=n;i++)
            {
                if (i % 3 == 0 && i % 7 == 0)
                    Console.Write(i+" ");
            }
        }
    }
}
