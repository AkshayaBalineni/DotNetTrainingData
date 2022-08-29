using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPrograms.cs
{
    public class SortingOddPositions
    {
        public void Main()
        {
            Console.WriteLine("enter the numbers");
            string str = Console.ReadLine();
            string[] arr = str.Trim().Split(',');
            int[] arrnew = Array.ConvertAll(arr,int.Parse);
            int temp;
            for (int i = 0; i < arrnew.Length; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = i + 2; j < arrnew.Length; j = j + 2)
                    {
                        if (arrnew[i] < arrnew[j])
                        {
                            temp = arrnew[i];
                            arrnew[i] = arrnew[j];
                            arrnew[j] = temp;
                        }
                    }
                }
                if (i % 2 != 0)
                {
                    for (int j = i + 2; j < arrnew.Length; j = j + 2)
                    {
                        if (arrnew[i] > arrnew[j])
                        {
                            temp = arrnew[i];
                            arrnew[i] = arrnew[j];
                            arrnew[j] = temp;
                        }
                    }
                }
            }
                /*if (i + 2 >= arrnew.Length)
                    break;
                if (arrnew[i] > arrnew[i + 2])
                {
                    temp = arrnew[i];
                    arrnew[i] = arrnew[i + 2];
                    arrnew[i + 2] = temp;
                }*/
            foreach (var item in arrnew)
            {
                Console.Write(item + ",");
            } 
        }
        
    }
}
