using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_akshaya_
{
    class Fibinocci
    {
        public void Main()
        {
            int n=0 ;
            Console.WriteLine("Enter the range:");
            n = Convert.ToInt32(Console.ReadLine());
            FibinocciSeries(n);
        }

        public void FibinocciSeries(int n)
        {
            int  f1 = 0, f2 = 1, f3 = 0;
            Console.WriteLine($"{f1}");
            Console.WriteLine($"{f2}");
            while (n >2)
            {
                f3 = f1 + f2;
                Console.WriteLine($"{f3}");
                f1 = f2;
                f2 = f3;
                n--;
            }
            Console.ReadKey();
        }
    }
}
