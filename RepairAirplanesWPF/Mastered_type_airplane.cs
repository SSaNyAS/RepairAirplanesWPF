//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RepairAirplanesWPF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Mastered_type_airplane
    {
        public long pilot_id { get; set; }
        public long airplane_id { get; set; }
        public Nullable<System.DateTime> flight_start_date { get; set; }
    
        public virtual Airplane Airplane { get; set; }
        public virtual Pilot Pilot { get; set; }
    }
}