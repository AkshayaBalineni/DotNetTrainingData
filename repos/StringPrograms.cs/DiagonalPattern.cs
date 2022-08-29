using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPrograms.cs
{
    public class DiagonalPattern
    {
        public void Main()
        {
            Console.WriteLine("Enter a string");
            string s = Console.ReadLine().Trim();
            char[] arr = s.ToCharArray();
            for(int i=0; i<arr.Length;i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if(i==j)
                    {
                        Console.Write(arr[j]);
                    }
                    if(i+j == arr.Length-1 && i!=j)
                    {
                        Console.Write(arr[j]);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
