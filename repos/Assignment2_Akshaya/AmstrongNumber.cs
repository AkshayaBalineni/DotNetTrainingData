using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_Akshaya
{
    class AmstrongNumber
    {
       
        public void Main()
        {
            int n;
            Console.WriteLine("Enter a Positive Number:");
            n = Convert.ToInt32(Console.ReadLine());
            CheckAmstrong(n);
        }

        public void CheckAmstrong(int  n)
        {
            int temp = n,rem=0, Amstrong=0;
            while(n>0)
            {
                rem = n % 10;
                Amstrong += rem * rem * rem;
                n = n / 10;

            }
            if (temp == Amstrong)
                Console.WriteLine($"{temp} is an Amstrong number.");
            else
                Console.WriteLine($"{temp} is not an Amstrong number");
        }
    }
}
