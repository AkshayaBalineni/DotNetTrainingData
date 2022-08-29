using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_akshaya_
{
    class IntToString
    {
        public void main()
        {
            Console.WriteLine("enter any integer");
            int n = Convert.ToInt32(Console.ReadLine());
            String s = ConvertingInToString(n);
            Console.WriteLine($"String = {s}");
            Console.ReadKey();
        }

        public string ConvertingInToString(int n)
        {
            return n.ToString();
        }
    }
}
