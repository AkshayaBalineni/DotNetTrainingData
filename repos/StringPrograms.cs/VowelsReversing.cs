using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPrograms.cs
{
    public class VowelsReversing
    {
        public void Main()
        {
            Console.WriteLine("Enter a String:");
            string s = Console.ReadLine().Trim().ToLower();
            string vowels = "aeiou";
            string str = "";
            char[] ch = s.ToCharArray();
            for (int i = 0; i < ch.Length; i++)
            {
                if (vowels.Contains(ch[i]))
                {
                    str = str + ch[i];
                }
            }
            int j = 0;
            for (int i = ch.Length - 1; i >= 0; i--)
            {
                if (vowels.Contains(ch[i]))
                {
                    ch[i] = str[j++];
                }
            }
            for (int i = 0; i < ch.Length; i++)
            {
                Console.Write(ch[i]);
            }
        }
    }
}
