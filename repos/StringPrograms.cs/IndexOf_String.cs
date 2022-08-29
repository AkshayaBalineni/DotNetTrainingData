using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPrograms.cs
{
    public class IndexOf_String
    {
        public void Main()
        {
            string str = "this is a test";
            Console.WriteLine(str);
            int start = 0, pos = 0;
            while ((str.Length > start) && (pos > -1))
            {
                pos = str.IndexOf('t', start);
                if (pos == -1)
                    break;
                Console.WriteLine(pos);
                start = pos + 1;
            }
            Console.WriteLine();
        }
    }
}
