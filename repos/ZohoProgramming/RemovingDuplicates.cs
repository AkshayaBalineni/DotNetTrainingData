using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZohoProgramming
{
    public class RemovingDuplicates
    {
        public void Mian()
        {
            Console.WriteLine("Enter a array:");
            int[] arr = Array.ConvertAll(Console.ReadLine().Trim().Split(','), int.Parse);
            int[] newArr = new int[arr.Length];
            //Array.Sort(arr);
            /*int count = 0;
            int duplicate = 0;*/
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        //duplicate +=1;
                        arr[j] = '_';
                    }
                }
            }
            int k = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] !='_')
                {
                    newArr[k++] = arr[i];
                }
            }
            for(int y=k;y<arr.Length;y++)
            {
                newArr[k++] = '-';
            }
            for (int i = 0; i < newArr.Length; i++)
            {
                if(newArr[i] != 45)
                {
                    Console.Write(newArr[i] + " ");
                }
                else
                {
                    Console.Write("_ ");
                }
                
            }
        }
    }
}
