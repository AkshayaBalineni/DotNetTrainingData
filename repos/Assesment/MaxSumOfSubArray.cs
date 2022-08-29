using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akshaya_Assesment
{
    public class MaxSumOfSubArray
    {
         public void Main()
        {
            Console.WriteLine("Enter the size of the array :");
            int ch = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[ch];
            Console.WriteLine("Enter the Elements :");
            for (int i = 0; i < ch; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }    
             MaxSum(array);
        }

        private void MaxSum(int[] array)
        {
            int max = 0;
            int maxSubArryaStartIndex = 0;
            for(int i = 0; i < array.Length-2; i++)
            {
                int sum = 0;
                for (int j=i; j<=i+2 ; j++)
                {
                    sum += array[j];
                }
                if(sum > max)
                {
                    max = sum;
                    maxSubArryaStartIndex = i;
                }
            }
            Console.WriteLine("************************");
            for(int k = maxSubArryaStartIndex; k< maxSubArryaStartIndex + 3; k++)
            {
                Console.Write($"{array[k]}, ==> ");
            }
            Console.WriteLine("sum= "+max);
        }
    }
}
