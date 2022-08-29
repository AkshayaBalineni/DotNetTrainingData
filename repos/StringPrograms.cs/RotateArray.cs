using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPrograms.cs
{
    public class RotateArray
    {
        public void Main()
        {
            Console.WriteLine("Enter a Array:");
            int[] arr = Array.ConvertAll(Console.ReadLine().Trim().Split(','), int.Parse);
            Console.WriteLine("Enter No.of rotations:");
            int num = Convert.ToInt32(Console.ReadLine());
            int temp = 0,j = 0;
            for (int i = 0; i < num; i++)
            {
                temp = arr[arr.Length - 1];
                for (j = arr.Length-1;j>0;j--)
                {
                    arr[j] = arr[j - 1];
                }
                arr[0] = temp;

            }
            foreach(var i in arr)
            {
                Console.Write(i+" ");
            }
        }
    }
}
