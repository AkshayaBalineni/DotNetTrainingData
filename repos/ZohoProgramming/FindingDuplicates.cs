using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZohoProgramming
{
    class FindingDuplicates
    {
            public void Main()
            {
                string s = "Codingg code";
                char[] ch = new Char[s.Length];

                for (int i = 0; i < s.Length; i++)
                {
                    ch[i] = s[i];
                }
                for (int i = 0; i < s.Length - 1; i++)
                {
                    for (int j = i + 1; j < s.Length; j++)
                    {
                        if (ch[i] == ch[j])
                        {
                            Console.WriteLine(ch[j]);

                        }
                    }

                }
            }
        
    }
}
