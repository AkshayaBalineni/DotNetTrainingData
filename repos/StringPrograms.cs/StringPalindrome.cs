using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPrograms.cs
{
    class StringPalindrome
    {
        public void Main()
        {
            Console.WriteLine("Enter a String:");
            string s = Console.ReadLine();
            string str = s.ToLower().Trim();
            int min = 0,max=s.Length-1;
            bool isPlaindrome = false;
            while(min<s.Length && max>=0)
            {
                if(str[min]==str[max])
                {
                    min++;
                    max--;
                    isPlaindrome = true;
                }
                else
                {
                    isPlaindrome = false;
                    break;
                }
            }
            if(isPlaindrome)
            {
                Console.WriteLine("palindrome");
            }
            else
            {
                Console.WriteLine("Not a palindrome");

            }

        }
    }
}
