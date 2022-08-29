using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akshaya_Assessment2
{
    public class Manager :Employee
    {
        private double specialAllowances;
        public Manager(double amount)
        {
            this.specialAllowances = amount;
        }
    }
}
