using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akshaya_Assessment2
{
    public class SalesPerson : Employee
    {
        private double monthTarget;
        private double salesAcheived;
        public SalesPerson(double monthTarget,double salesAcheived)
        {
            this.monthTarget = monthTarget;
            this.salesAcheived = salesAcheived;
        }
    }
}
