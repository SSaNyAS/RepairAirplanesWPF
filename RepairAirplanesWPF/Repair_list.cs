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
    using RepairAirplanesWPF.Extensions;
    using System;
    using System.Collections.Generic;
    
    public partial class Repair_list
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Repair_list()
        {
            this.Required_repair_work = new HashSet<Required_repair_work>();
        }
    
        public long id { get; set; }
        public long airplane_id { get; set; }
        public System.DateTime start_repair_date { get; set; }
        public Nullable<System.DateTime> end_repair_date { get; set; }
        public string additional_information { get; set; }
        public string Status => this.GetStatus();
        public virtual Airplane Airplane { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Required_repair_work> Required_repair_work { get; set; }
    }
}
