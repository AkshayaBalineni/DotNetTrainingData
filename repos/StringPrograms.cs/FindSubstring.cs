using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPrograms.cs
{
    public class FindSubstring
    {
        public void Main()
        {
            Console.WriteLine("Enter a string1");
            string s1 = Console.ReadLine().Trim();
            Console.WriteLine("Enter a string2");
            string s2 = Console.ReadLine().Trim();
            var pos = s1.IndexOf(s2);
            Console.WriteLine(pos);
        }
    }
}
