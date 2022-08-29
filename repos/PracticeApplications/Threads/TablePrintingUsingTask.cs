using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    public class TablePrintingUsingTask
    {
        public void Main()
        {
            int n = 5;
            Task task = new Task(() => PrintingTables(n));
            task.Start();
        }

        private void PrintingTables(int n)
        {
            for(int i=1;i<=10;i++)
            {
                for(int j = 1; j <= 5; j++)
                {
                    Console.Write($"{j} * {i} ={i * j}\t");
                }
                Console.WriteLine();
            }
        }
    }
}
