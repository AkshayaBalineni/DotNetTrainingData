using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPrograms.cs
{
    public class FirstMissingPositiveNumber
    {
        /*public void Main()
        {
            Console.WriteLine("Enter a Array:");
            int[] arr = Array.ConvertAll(Console.ReadLine().Trim().Split(','), int.Parse);
            for(int i =0;i<arr.Length;i++)
            {
                int next = arr[i] + 1;
                int found = 0;
                for(int j = 0; j<arr.Length;j++)
                {
                    if(arr[j] == next)
                    {
                        found++;
                    }
                }
                
            }
            
        }*/
        public void Main()
        {
            Console.WriteLine("Enter a Array:");
            int[] arr = Array.ConvertAll(Console.ReadLine().Trim().Split(','), int.Parse);
            int temp = 0;
            for (int i = 0; i < arr.Length-1; i++)
            {
                for(int j=i+1;j<arr.Length;j++)
                {
                    if(arr[i]>arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[0]>1)
                {
                    Console.WriteLine(1);
                    break;
                }
                else if(i == arr.Length-1)
                {
                    Console.WriteLine(arr[i]+1);
                    break;
                }
                else if(arr[i+1] != arr[i]+1)
                {
                    Console.WriteLine(arr[i] + 1);
                }
            }

        }
    }
}
