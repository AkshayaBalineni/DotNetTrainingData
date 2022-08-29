using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    public  class TaskDemo
    {
        public async void main()
        {
           await PrintNumber(10);
        }
    
        public async Task PrintNumber(int n)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine(i);
                }
            });
        }
    }
}
