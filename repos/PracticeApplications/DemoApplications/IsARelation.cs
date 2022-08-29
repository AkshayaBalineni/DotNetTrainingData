using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplications
{
    class IsARelation
    {
        public IsARelation()
        {

        }
        public virtual int Marks { get; set; }
        public  IsARelation(int marks)
        {
            this.Marks = marks;
        }
        public void Main()
        {
            IsARelation d = new Derived(10);
            Console.WriteLine(d.Marks);
        }
    }
    class Derived :IsARelation
    {
        public override int Marks { get; set; }
        public  Derived(int marks):base(marks)
        {
            this.Marks = marks + 10;
        }
    }
    
}
