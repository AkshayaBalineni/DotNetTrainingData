using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akshaya_Assessment2
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public Manager Manager { get; set; }
    }
}
