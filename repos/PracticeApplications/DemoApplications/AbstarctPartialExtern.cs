using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplications
{
     partial  class circle1
    {
         partial void Area();
        
    }
     class circle2 :circle1
    {
       public void Area()
        {
            Console.WriteLine("Area");
        }
    }
    class Circle
    {/*
        [DllImport("User32., CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr h, string m, string c, int type);

        public int  Main()
        {
            string myString;
            Console.Write("Enter your message: ");
            myString = Console.ReadLine();
            return MessageBox((IntPtr)0, myString, "My Message Box", 0);
        }*/

        public void Main()
        {
            circle2 obj = new circle2();
            obj.Area();
        }
    }
    /*abstract class  AbstarctClass :        
    {
        public abstract void Method1();
      //  public extern void Method2();
    }
   

    class Impl : AbstarctClass
    {
        public override void Method1()
        {
            Console.WriteLine("Abstract method Impl");
        }
        

    }*/

}
