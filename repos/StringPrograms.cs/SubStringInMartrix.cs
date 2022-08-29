using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPrograms.cs
{
    public class SubStringInMartrix
    {
        public void Main()
        {
            string s = "WELCOMETOZOHOCORPORATION";
            char[] ch = s.ToCharArray();
            int k = 0;
            char[,] matrix = new char[(int)Math.Ceiling(Math.Sqrt(s.Length)), (int)Math.Ceiling(Math.Sqrt(s.Length))];
            for (int i = 0; i < (Math.Ceiling(Math.Sqrt(s.Length))) && k < ch.Length; i++)
            {
                for (int j = 0; j < (Math.Ceiling(Math.Sqrt(s.Length))) && k < ch.Length; j++)
                {
                    matrix[i, j] = ch[k++];
                }
                Console.WriteLine();
            }
            for (int i = 0; i < (Math.Ceiling(Math.Sqrt(s.Length))) && k < ch.Length; i++)
            {
                for (int j = 0; j < (Math.Ceiling(Math.Sqrt(s.Length))) - 2 && k < ch.Length; j++)
                {
                    if (matrix[i, j] == 'T' && matrix[i, j + 1] == 'O' && matrix[i, j + 2] == 'O')
                    {
                        Console.WriteLine($"start<{i},{j}> End<{i}{j + 2}");
                        break;
                    }
                }
                Console.WriteLine();
            }
            for(int i = 0; i < (Math.Ceiling(Math.Sqrt(s.Length))) && k < ch.Length; i++)
            {
                for (int j = 0; j < (Math.Ceiling(Math.Sqrt(s.Length))) - 2 && k < ch.Length; j++)
                {
                    if (matrix[j, i] == 'T' && matrix[j, i + 1] == 'O' && matrix[j, i + 2] == 'O')
                    {
                        Console.WriteLine($"start<{i},{j}> End<{i}{j + 2}");
                        break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
