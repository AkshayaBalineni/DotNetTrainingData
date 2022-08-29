using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    public class TablePrintingUsingTaskV1
    {
        public void Main()
        {
           
            
           // int n = 5;
            Task task1 = Task.Factory.StartNew(() => PrintingTables1(1));
            Task task2 = Task.Factory.StartNew(() => PrintingTables2(2));
            Task task3 = Task.Factory.StartNew(() => PrintingTables3(3));
            Task task4 = Task.Factory.StartNew(() => PrintingTables4(4));
            //task.Start();
        }

        private void PrintingTables1(int n)
        {
            for(int i=1;i<=10;i++)
            {
                Console.Write($" {n} * {i} = {n * i}\t");
                Thread.Sleep(100);
            }
            Console.WriteLine();
        }
        private void PrintingTables2(int n)
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"{n} * {i} = {n * i}\t");
                Thread.Sleep(100);
            }
            Console.WriteLine();
        }
        private void PrintingTables3(int n)
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.Write($" {n} * {i} = {n * i}\t");
                Thread.Sleep(100);
            }
            Console.WriteLine();
        }
        private void PrintingTables4(int n)
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.Write($" {n} * {i} = {n * i}\t");
                Thread.Sleep(100);
            }
            Console.WriteLine();
        }
    }
}
