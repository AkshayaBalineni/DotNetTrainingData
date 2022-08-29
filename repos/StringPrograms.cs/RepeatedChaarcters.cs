using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPrograms.cs
{
    class RepeatedChaarcters
    {
        public void Main()
        {
            Console.WriteLine("enter the string");
            string s = Console.ReadLine().Trim();
            string str = string.Empty;
            int num = 0;
            for (int i =0;i<s.Length;i++)
            {
                if(Char.IsLetter(s[i]))
                {
                    str = str + s[i];
                }
                if (char.IsNumber(s[i]))
                {
                    int n = (int)Char.GetNumericValue(s[i]);
                    num = num * 10 + n;

                    if (i == s.Length - 1 || Char.IsLetter(s[i + 1]))
                    {
                        for (int j = 0; j < num; j++)
                        {
                            Console.Write(str);
                        }
                        str = string.Empty;
                        num = 0;
                    }
                }
                
            }
        }
    }
}
/*char[] ch = s.ToCharArray();
            char c =' ';
            for(int i = 0; i < s.Length; i++)
            {
                if(Char.IsLetter(ch[i]))
                {
                    c = ch[i];
                }
                else if(char.IsNumber(ch[i]))
                {
                    int n = (int)Char.GetNumericValue(ch[i]);
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(c);
                    }
                }
                *//*else
                {
                    Console.WriteLine("Invalid Input");
                break;
                }*/