using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPrograms.cs
{
   public class PossibleSubstrings
    {
        public void Main()
        {
            Console.WriteLine("Enter a String:");
            string s = Console.ReadLine();
            if (string.IsNullOrEmpty(s))
            {
                Console.WriteLine("string is empty");
            }
            for(int i = 1;i<s.Length;i++)
            {
                for(int j=0;j<=s.Length-i;j++)
                {
                    Console.WriteLine(s.Substring(j, i));
                }
            }
        }
    }
}
