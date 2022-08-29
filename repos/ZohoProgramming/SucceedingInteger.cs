using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZohoProgramming
{
    public class SucceedingInteger
    {
        public void Main()
        {
            Console.WriteLine("Enter a array");
            int[] num = Array.ConvertAll(Console.ReadLine().Trim().Split(','), int.Parse);
            /*
            for(int i =0; i<resultArray.Length;i++)
            {
                resultArray[i] = -1;
            }*/
            int[] resultArray = new int[num.Length + 1];
            for (int i = num.Length-1;i>=0;i--)
            {
                if(num[i]+1 > 9)
                {
                    //char[] ch = new char[resultArray.Length];
                    string s = num[i] + 1.ToString();
                    //string next = 
                    for (int j = 0; j < num.Length-2; j++)
                    { 
                        
                    }
                    
                }
            }
        }
    }
}
