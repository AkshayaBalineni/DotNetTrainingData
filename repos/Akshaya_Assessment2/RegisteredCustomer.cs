using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akshaya_Assessment2
{
    public enum SpecialPrivilegaesTypes
    {
        silver = 15,
        gold = 20,
        platinum = 25
    }
    public class RegisteredCustomer : Customer
    {
        private double regFee;
        private DateTime date;

        public RegisteredCustomer(double regFee,DateTime date)
        {
            this.regFee = regFee;
            this.date = date;
        }
    }
}
