//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MassageApplication.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Massage_Slots
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Massage_Slots()
        {
            this.Bookings = new HashSet<Booking>();
        }
    
        public int id { get; set; }
        public int massage_day_id { get; set; }
        public System.DateTime start_hour { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual Massage_Days Massage_Days { get; set; }
    }
}
