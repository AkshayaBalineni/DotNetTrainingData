using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_akshaya_
{
    class NumberToWord
    {
        public void Main()
        {
            int number = 0,  next = 0, num_digits = 0;
            int[] a = new int[10];
            string[] digits_words = {  "zero", "one","two","three","four",
                "five","six","seven","eight","nine"};
            Console.WriteLine("Enter a number:");
            String input = Console.ReadLine();
            
            bool b = int.TryParse(input, out number);
            if (b)
            {
                number = Convert.ToInt32(input); //
                if (number > 0)
                    while (number > 0)
                    {
                        next = number % 10;
                        a[num_digits] = next;
                        num_digits++;
                        number = number / 10;
                    }
           
            num_digits--;
            Console.Write("Number in words: ");
            for (; num_digits >= 0; num_digits--)
                Console.Write(digits_words[a[num_digits]] + " ");
            }
            else
                Console.WriteLine("Enter the valid output");
            Console.ReadKey();
        }
    }
}
