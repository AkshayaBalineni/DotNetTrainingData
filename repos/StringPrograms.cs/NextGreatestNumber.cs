using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPrograms.cs
{
    public class NextGreatestNumber
    {
        public void Main()
        {
            Console.WriteLine("Enter a Array:");
            int[] arr = Array.ConvertAll(Console.ReadLine().Trim().Split(','), int.Parse);
            int[] newArr = new int[arr.Length];
            for(int i = 0;i<arr.Length;i++)
            {
                int changed = 0;
                for (int j = i+1; j < arr.Length; j++) 
                {
                    if(arr[i] < arr[j])
                    {
                        newArr[i] = arr[j];
                        changed++;
                        break;
                    }
                }
                if(changed==0)
                {
                    newArr[i] = -1;
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(newArr[i]+" ");
            }

            }
    }
}
