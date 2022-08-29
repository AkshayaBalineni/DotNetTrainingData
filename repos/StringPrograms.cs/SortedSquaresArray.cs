using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPrograms.cs
{
    public class SortedSquaresArray
    {
        public void Main()
        {
            Console.WriteLine("Enter a Array:");
            int[] arr = Array.ConvertAll(Console.ReadLine().Trim().Split(','), int.Parse);
            for(int i =0;i<arr.Length;i++)
            {
                arr[i] = arr[i] * arr[i];
            }
            for (int i = 0; i < arr.Length-1; i++)
            {
                int temp = 0;
                for(int j =i+1;j < arr.Length; j++)
                {
                    if(arr[i]>arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            foreach (var item in arr)
            {
                Console.Write(item +" ");
            }
        }
    }
}
