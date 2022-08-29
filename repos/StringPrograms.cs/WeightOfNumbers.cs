using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPrograms.cs
{
    public class WeightOfNumbers
    {
        public void Main()
        {
            Console.WriteLine("Enter a Array:");
            string[] s = Console.ReadLine().Trim('<','>').Split(',');
            int[] arr = Array.ConvertAll(s, int.Parse);
            for(int i = 0;i<arr.Length;i++)
            {
                int weight = 0;
                if (Math.Sqrt(arr[i])%1==0)
                {
                    weight = 5;
                }
                if(arr[i] % 4 == 0 && arr[i] % 6 ==0)
                {
                    weight += 4;
                }
                if(arr[i] % 2 == 0)
                {
                    weight += 3;
                }
                Console.Write($"<{arr[i]},{weight}>");
            }
            Console.WriteLine();
            foreach (var item in arr)
            {
                for(int i =1;i*i<=item;i++)
                {
                    if(item% i==0 && item /i ==i)
                    {
                        Console.WriteLine($"{item}--perfect square");
                    }
                }
            }
        }
    }
}
