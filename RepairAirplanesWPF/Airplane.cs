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
    
    public partial class Airplane
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Airplane()
        {
            this.Flight_log = new HashSet<Flight_log>();
            this.Mastered_type_airplane = new HashSet<Mastered_type_airplane>();
            this.Recommended_repair_period = new HashSet<Recommended_repair_period>();
            this.Repair_list = new HashSet<Repair_list>();
        }
    
        public long id { get; set; }
        public string model { get; set; }
        public Nullable<int> max_speed { get; set; }
        public Nullable<int> max_height { get; set; }
        public Nullable<int> max_fly_distance { get; set; }
        public int pilots_seat_count { get; set; }
        public int passengers_seat_count { get; set; }
        public Nullable<int> fuel_capacity { get; set; }
        public Nullable<int> load_capacity { get; set; }
        public long engine_id { get; set; }
    
        public virtual Engine Engine { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Flight_log> Flight_log { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mastered_type_airplane> Mastered_type_airplane { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recommended_repair_period> Recommended_repair_period { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Repair_list> Repair_list { get; set; }
    }
}
