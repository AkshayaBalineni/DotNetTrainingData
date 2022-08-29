using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZohoProgramming
{
    public class SuccedingIntegerArray
    {
        public void Main()
        {
            Console.WriteLine("enter a number:");
            string s =Console.ReadLine();
            long.TryParse(s, out long num);
            //char[] ch = new char[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                Console.Write(s[i] + " ");
            }
            long nextNum = num + 1;
            string s1 = nextNum.ToString();
            Console.WriteLine();
            for (int i = 0; i < s1.Length; i++)
            {
                Console.Write(s1[i] + " ");
            }
        }
    }
}
