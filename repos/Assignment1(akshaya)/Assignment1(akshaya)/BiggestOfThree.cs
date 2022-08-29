using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_akshaya_
{
    class BiggestOfThree
    {
        public void main()
        {
            int num1, num2, num3;
            Console.WriteLine("Enter the three numbers:");
            num1 = Convert.ToInt32(Console.ReadLine());
            num2 = Convert.ToInt32(Console.ReadLine());
            num3 = Convert.ToInt32(Console.ReadLine());
            int biggest = GreatestOfThree(num1, num2, num3);
            int ternary = TernaryOperator(num1, num2, num3);
            Console.WriteLine($"Biggest of {num1},{num2} and {num3} is {biggest}");
            Console.WriteLine($"Biggest of three numbers using ternary {ternary}");
            Console.ReadKey();
        }

        public int TernaryOperator(int num1, int num2, int num3)
        {
            return num1 > num2 ? (num1 > num3 ? num1 : num3) : (num2 > num3 ? num2 : num3);
            
        }

        public int GreatestOfThree(int num1, int num2, int num3)
        {
            if (num1 > num2 && num1 > num3)
                return num1;
            else if (num2 > num3)
                return num2;
            else
                return num3;
        }
    }
}
