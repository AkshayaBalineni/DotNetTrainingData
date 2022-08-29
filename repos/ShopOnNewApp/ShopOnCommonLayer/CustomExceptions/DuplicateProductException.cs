using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnCommonLayer.CustomExceptions
{
    public class DuplicateProductException :ApplicationException
    {
        public DuplicateProductException()
        {

        }
        public DuplicateProductException(string errormsg):base(errormsg)
        {

        }
        //to store in log file
        public DuplicateProductException(string msg , Exception exception):base(msg,exception)
        {

        }
    }
}
