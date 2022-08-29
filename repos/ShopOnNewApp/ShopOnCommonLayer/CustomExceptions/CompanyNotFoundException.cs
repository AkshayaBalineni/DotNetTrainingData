using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnCommonLayer.CustomExceptions
{
    public class CompanyNotFoundException : ApplicationException
    {
        public CompanyNotFoundException()
        {

        }
        public CompanyNotFoundException(string msg) : base(msg)
        {

        }
        public CompanyNotFoundException(string msg,Exception exception):base(msg,exception)
        {

        }
    }
}
