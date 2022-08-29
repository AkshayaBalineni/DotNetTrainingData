using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPrograms.cs
{
    public class KaperkarNumer
    {
        public void Main()
        {
            Console.WriteLine("Enter a Number:");
            int num = Convert.ToInt32(Console.ReadLine());
            int square = num * num;
            int temp = square;
            int rem = 0;
            int divisor = 10;
            bool isKaprekar = false;
           // int rem = square % divisor;
            //int quotient = square / divisor;
            while(temp!=0)
            {
                rem = square % divisor;
                temp = temp / 10;
                divisor *= 10;
                if (rem+temp == num)
                {
                    Console.WriteLine(num + "is a Kaprekar Number");
                    isKaprekar = true;

                    break;
                }
                
            }
            if(!isKaprekar)
            Console.WriteLine(num + "is a Not Kaprekar Number");
        }
    }
}
