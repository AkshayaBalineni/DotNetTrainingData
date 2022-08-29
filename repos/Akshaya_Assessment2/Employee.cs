using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akshaya_Assessment2
{
    public enum Band
    {
        level1,
        level2,
        level3,
        level4
    }
    public class Employee :Person
    {
        public double BasicSalary { get; set; }
        public int EmployeeId { get; set; }
        public Department Department { get; set; }

    }
}
