using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnCommonLayer.Models
{
    public class RegisteredCustomer : Customer
    {
        public int  Discount { get;  }
        public RegisteredCustomer(int discount)
        {
            this.Discount = discount;
        }

        public override double GetCustomerTotal()
        {
            double total = 0;
            var originalAmount = base.GetCustomerTotal();
            var discount = originalAmount * this.Discount / 100;
            total = originalAmount - discount;

            return total;
        }

    }
}
