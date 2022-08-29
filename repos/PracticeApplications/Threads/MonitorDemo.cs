using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    public class Printer
    {

    }
    public class MonitorDemo
    {
        private readonly string msg;
        private readonly Printer printer;
        public MonitorDemo()
        {

        }
        public MonitorDemo(Printer printer,string msg)
        {
            this.printer = printer;
            this.msg = msg;
        }
        public void  Run()
        {
            // Monitor.Enter(printer);
            lock (printer)
            {
                try
                {
                    Console.WriteLine(msg);
                }
                catch (Exception)
                { }
            }
            
            /*try
            {
                Console.WriteLine(msg);
            }
            catch(Exception)
            {

            }
            Monitor.Exit(printer);*/
        }
        public void Main()
        {
            Printer printer = new Printer();
            MonitorDemo obj1 = new MonitorDemo(printer, "one");
            MonitorDemo obj2 = new MonitorDemo(printer,"two");
            MonitorDemo obj3 = new MonitorDemo(printer,"three");

            Thread t1 = new Thread(new ThreadStart(obj1.Run));
            Thread t2 = new Thread(new ThreadStart(obj2.Run));
            Thread t3 = new Thread(new ThreadStart(obj3.Run));
            t1.Start();
            t2.Start();
            t3.Start();


        }


    }
}
