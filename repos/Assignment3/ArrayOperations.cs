using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class ArrayOperations
    {
        public void Main()
        {
            int[,] arr = new int[3, 3];
            int i=0,j=0;
            Console.WriteLine("Enter the elemets of an array:");
            for ( i = 0; i < 3; i++)
                for (j = 0; j < 3; j++)
                    arr[i,j] =Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("original Array");
            Console.WriteLine("**************************");
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                    Console.Write(arr[i, j]+" ");
                Console.WriteLine();
            }
            FirstRow(arr);
            LastRow(arr);
            FirstCol(arr);
            LastCol(arr);
            PrimaryDiag(arr);
            SecondaryDiag(arr);

        }

        private void SecondaryDiag(int[,] arr)
        {
            Console.WriteLine("SecondaryDiagonal");
            Console.WriteLine("**************************");
            int j = 3 - 1;
            for (int i = 0; i < 3; i++)
                Console.WriteLine(arr[i, j--]);
   
            
        }

        private void PrimaryDiag(int[,] arr)
        {
            Console.WriteLine("PrimaryDiagonal");
            Console.WriteLine("**************************");
            int i = 0,j = 0;
            for (int ele = 0; ele < 3*3; ele++)
            {
                i = ele / 3;
                j = ele % 3;
                if (i==j)
                 Console.WriteLine(arr[i, j] + " ");
            }                 
        }
        private void LastCol(int[,] arr)
        {
            Console.WriteLine("LastColumn");
            Console.WriteLine("**************************");
            for (int ele = 0; ele < 3; ele++)
                Console.WriteLine(arr[ele,2]);

        }

        private void FirstCol(int[,] arr)
        {
            Console.WriteLine("FirstColumn");
            Console.WriteLine("**************************");
            for (int ele = 0; ele < 3; ele++)
                Console.WriteLine(arr[ele, 0]);

        }

        private void LastRow(int[,] arr)
        {
            Console.WriteLine("LastRow");
            Console.WriteLine("**************************");
            for (int ele = 0; ele < 3; ele++)
                Console.WriteLine(arr[2, ele]);

        }
        private void FirstRow(int[,] arr)
        {
            Console.WriteLine("FirstRow");
            Console.WriteLine("**************************");
            for (int ele = 0; ele < 3; ele++)
                Console.WriteLine(arr[0, ele]);

        }
    }
}
