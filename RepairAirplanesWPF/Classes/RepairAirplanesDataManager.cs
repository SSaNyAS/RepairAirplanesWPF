using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBManager;
namespace RepairAirplanesWPF.Classes
{
    class RepairAirplanesDataManager
    {
        private object Context;

        public RepairAirplanesDataManager(object context)
        {
            this.Context = context;
        }

    }
}
