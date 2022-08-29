using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnCommonLayer.Models
{
   public class CustomerAddress
    {
        public Customer Customer { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
