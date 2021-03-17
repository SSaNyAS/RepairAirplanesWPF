using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairAirplanesWPF.Extensions
{
    static class RepairListExtension
    {
        public static string GetStatus(this Repair_list repair_List)
        {
            var status = "Выполняется";
            for (int i = 0; i < repair_List.Required_repair_work.Count; i++)
            {
                var work = repair_List.Required_repair_work.ElementAt(i);

                if (work.Repair_status.id == 1)
                {
                    return work.Repair_status.name;
                }
            }
            status = "Завершено";
            return status;
        }
    }
}
