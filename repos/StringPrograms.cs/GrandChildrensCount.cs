using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPrograms.cs
{
    public class GrandChildrensCount
    {
        public void Main()
        {
            int grandchildren = 0;
            string son =" ";
            string[,] sonFather = new string[,] { { "luke", "shaw" }, { "wayne", "rooney" }, { "rooneyi", "wayne" }, { "shaw", "rooney" } };
            /*for(int i=0;i<4;i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    sonFather[i,j] = Console.ReadLine();
                }
            }*/
            Console.WriteLine("enter father:");
            string father = Console.ReadLine();
            for (int i = 0; i < 4; i++)
            {
                if(sonFather[i,1].ToLower().Equals(father))
                {
                    son = sonFather[i,0];
                    for (int j = 0; j < 4; j++)
                    {
                        if (son.ToLower().Equals(sonFather[j, 1]))
                        {
                            grandchildren++;
                        }
                    }
                }
            }
            Console.WriteLine($"Grandchilderens of {father} is {grandchildren}");
        }
    }
}
