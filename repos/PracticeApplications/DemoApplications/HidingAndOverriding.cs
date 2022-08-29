using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplications
{

   class ClassA
    {
        public virtual void Method1()
        {
            Console.WriteLine("Method 1 from classA");
        }
        public void Method2()
        {
            Console.WriteLine("Method 2 from classA");
        }
    }
    class ClassB :ClassA
    {
        public override void Method1()
        {
            Console.WriteLine("Method 1 from class B");
        }
        public new void Method2()
        {
            Console.WriteLine("Method 2 from classB");
        }
    }
    public class HidingAndOverriding
    {
        public void main()
        {
            ClassB objB = new ClassB();
            objB.Method1();
            objB.Method2();
            ClassA objA = new ClassA();
            objA.Method1();
            ClassA obj = new ClassB();
            obj.Method1();
            obj.Method2();
        }
    }
}
   
