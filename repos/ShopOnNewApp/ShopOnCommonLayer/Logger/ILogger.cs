using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnCommonLayer.Logger
{
    public interface ILogger
    {
       public void WriteLog(Exception exception);
    }
}
