using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriendList
{
    class BestFriendList
    {
        public void Main()
        {
            List<string> girls = new List<string>();
            girls.Add("Anu");
            girls.Add("Akshaya");
            girls.Add("Maneesha");
            girls.Add("Kavya");
            girls.Add("Kusuma");

            List<string> boys = new List<string>();
            boys.Add("Sharuk");
            boys.Add("Ajay");
            boys.Add("Dinesh");
            boys.Add("Aadi");

            List<string> schoolFriends = new List<string>();
            schoolFriends.Add(girls.ElementAt<string>(4));
            schoolFriends.Add(girls.ElementAt<string>(2));
            schoolFriends.Add(girls.ElementAt<string>(1));
            schoolFriends.Add(boys.ElementAt<string>(1));
            schoolFriends.Add(boys.ElementAt<string>(2));

            DisplayBestFriends(girls, boys, schoolFriends);

        }

        private void DisplayBestFriends(List<string> girls, List<string> boys, List<string> schoolFriends)
        {
            Console.WriteLine("Before ");
            DrawLine(50, "*");
            Console.WriteLine("Girls");
            DrawLine(50, "-");
            foreach(var girl in girls)
            {
                Console.WriteLine(girl);
            }
            DrawLine(50, "*");
            Console.WriteLine("Boys");
            DrawLine(50, "-");
            foreach (var boy in boys)
            {
                Console.WriteLine(boy);
            }
            DrawLine(50, "*");
            Console.WriteLine("School Friends");
            DrawLine(50, "-");
            foreach (var schlFrnd in schoolFriends)
            {
                Console.WriteLine(schlFrnd);
            }
            DrawLine(50, "*");
            List<string> bestFriends = new List<string>();
            foreach(var bestFrnd in schoolFriends)
            {
                if (girls.Contains(bestFrnd))
                {
                    bestFriends.Add(bestFrnd);
                    girls.Remove(bestFrnd);
                }
                if (boys.Contains(bestFrnd))
                {
                    bestFriends.Add(bestFrnd);
                    boys.Remove(bestFrnd);
                }
                    
            }
            Console.WriteLine("After ");
            DrawLine(50, "*");
            Console.WriteLine("Girls");
            DrawLine(50, "-");
            foreach (var girl in girls)
            {
                Console.WriteLine(girl);
            }
            DrawLine(50, "*");
            Console.WriteLine("Boys");
            DrawLine(50, "-");
            foreach (var boy in boys)
            {
                Console.WriteLine(boy);
            }
            DrawLine(50, "*");
            Console.WriteLine("School Friends");
            DrawLine(50, "-");
            foreach (var schlFrnd in schoolFriends)
            {
                Console.WriteLine(schlFrnd);
            }
            DrawLine(50, "-");
            Console.WriteLine("Best Friends");
            DrawLine(50, "-");
            foreach (var best in bestFriends)
            {
                Console.WriteLine(best);
            }

        }
        private void DrawLine(int v1, string v2)
        {
            for (int i = 0; i < v1; i++)
                Console.Write(v2);
            Console.WriteLine();
        }
    }  
}
