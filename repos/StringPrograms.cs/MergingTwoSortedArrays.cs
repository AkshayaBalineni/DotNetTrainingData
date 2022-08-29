using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPrograms.cs
{
   public class MergingTwoSortedArrays
    {
        public void Main()
        {
            Console.WriteLine("Enter a Array1:");
            string s1 = Console.ReadLine().Trim();
            string[] arr1 = s1.Split(',');
            int[] intArr1 = Array.ConvertAll(arr1, int.Parse);
            Console.WriteLine("Enter a Array2:");
            string s2 = Console.ReadLine().Trim();
            string[] arr2 = s2.Split(',');
            int[] intArr2 = Array.ConvertAll(arr2, int.Parse);
            int temp = 0;
            for (int i = 0; i < intArr1.Length; i++)
            {
                for (int j = 0; j < intArr2.Length; j++)
                {
                     if(intArr1[i] > intArr2[j])
                      {
                            temp = intArr1[i];
                            intArr1[i] = intArr2[j];
                            intArr2[j] = temp;
                      }
                }
            }
           Array.Sort(intArr2);
            foreach (var item in intArr1)
            {
                Console.Write(item +" ");
            }
            foreach (var item in intArr2)
            {
                Console.Write(item+" ");
            }

        }
    }
}
