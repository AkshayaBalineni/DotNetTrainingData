using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.CustomExceptions
{
    public class DuplicateContactException : ApplicationException
    {
        public DuplicateContactException()
        {
                
        }
        public DuplicateContactException(string errorMsg):base(errorMsg)
        {

        }
        public DuplicateContactException(string errorMsg, Exception exception) : base(errorMsg,exception)
        {

        }
    }
}
