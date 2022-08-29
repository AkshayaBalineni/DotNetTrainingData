using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPrograms.cs
{
    public  class CaptalizeEachLetterOfWord
    {
        public void Main()
        {
            /* Console.WriteLine("Enter a String:");
             string s = Console.ReadLine();*/
            string s = "this is a statement";
            string[] arr = s.Split(" ");
            foreach (var item in arr)
            {
                Console.Write(item.Trim().Substring(0, 1).ToUpper()+""+item.Substring(1,item.Length-1).ToLower());
                Console.Write(" ");
            }
        }
    }
}
