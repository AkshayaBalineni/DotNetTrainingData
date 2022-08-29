using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPrograms.cs
{
    public class ReverseOfWordsInString
    {
        public void Main()
        {
             Console.WriteLine("Enter a String:");
            string s = Console.ReadLine();
            int start = 0;
            int pos = 0;
            var length = s.Split(" ").Length;
            Console.WriteLine("No of words =" + length);
            while(start < s.Length && pos > -1)
            {
                pos = s.IndexOf(" ", start);
                for (int i = pos - 1; i >= start; i--)
                    Console.Write(s[i]);
                Console.Write(" ");
                start = pos + 1;
            }
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ' ')
                {
                    break;
                }
                Console.Write(s[i]);
            }


        }
    }
}
