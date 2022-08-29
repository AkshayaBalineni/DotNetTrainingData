using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainer_Trainee
{
   public class Module
    {
        public string ModuleName { get; set; }
        private List<Unit> units = new List<Unit>();

        public void AddUnit(Unit unit)
        {
            this.units.Add(unit);
        }
        public IEnumerable<Unit> GetUnits()
        {
            return this.units;
        }

    }
}
