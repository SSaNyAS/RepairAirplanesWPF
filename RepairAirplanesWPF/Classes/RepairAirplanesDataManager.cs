using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DBManager;
namespace RepairAirplanesWPF.Classes
{
    class RepairAirplanesDataManager
    {
        private DBLoader<Thread> AirplaneDataLoader;
        private DBLoader<Thread> PersonDataLoader;
        private DBLoader<Thread> RepairStatusDataLoader;
        private DBLoader<Thread> RepairWorkDataLoader;
        private DBLoader<Thread> RepairPartDataLoader;
        private DBLoader<Thread> RequiredRepairPartDataLoader;
        private DBLoader<Thread> RequiredRepairWorkDataLoader;
        private DBLoader<Thread> PermissionDataLoader;
        private DBLoader<Thread> PermissionGroupDataLoader;
        private DBLoader<Thread> PermissionForGroupDataLoader;
        private DBLoader<Thread> AuthorizationDataLoader;

        public RepairAirplanesDataManager()
        {

        }

    }
}
