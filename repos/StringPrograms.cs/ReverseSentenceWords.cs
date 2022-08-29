using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPrograms.cs
{
    public class ReverseSentenceWords
    {
        public void Main()
        {
            Console.WriteLine("Enter a String:");
            string s = Console.ReadLine().Trim();
            string[] arr = s.Trim().Split('.');
            Array.Reverse(arr);
            Console.Write(string.Join('.',arr));
        }
    }
}
