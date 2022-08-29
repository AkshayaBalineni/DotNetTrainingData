using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZohoProgramming
{
    public class DualSort
    {
        public void Main()
        {
            Console.WriteLine("Enter a array:");
            int[] arrnew = Array.ConvertAll(Console.ReadLine().Trim().Split(','), int.Parse);
            int temp = 0;
            for (int i = 0; i < arrnew.Length; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = i; j < arrnew.Length; j=j+2)
                    { 
                       
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
                if (i % 2 != 0)
                {
                    for (int j = i; j < arrnew.Length; j=j+2)
                    {
                      
                        {
                            if (arrnew[i] < arrnew[j])
                            {
                                temp = arrnew[i];
                                arrnew[i] = arrnew[j];
                                arrnew[j] = temp;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < arrnew.Length; i++)
            {
                Console.Write(arrnew[i]+" ");
            }
        }
    }
}
