using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_akshaya_
{
    class SwappingOfTwoNumbers
    {
        public void main()
        {
            Console.WriteLine("enter any 2 numbers:");
            int num1 = Convert.ToInt32 (Console.ReadLine());
            int num2 = Convert.ToInt32 (Console.ReadLine());
            Console.WriteLine($"before swapping n1={num1} and n2={num2}");
            Swaping(num1, num2);

        }

        public void Swaping(int num1, int num2)
        {
            int temp = num1;
            num1 = num2;
            num2 = temp;
            Console.WriteLine($"after Swapping n1={num1} and n2={num2}");
            Console.ReadKey();
        }
        
    }
}
