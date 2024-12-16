//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EF_DBFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hotel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hotel()
        {
            this.Room = new HashSet<Room>();
        }
    
        public int id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public System.Guid Guid { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public System.DateTime AddedTime { get; set; }
        public int AddedUser { get; set; }
        public string AddedIP { get; set; }
        public System.DateTime UpdatedTime { get; set; }
        public int UpdatedUser { get; set; }
        public string UpdatedIP { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Room> Room { get; set; }
    }
}
