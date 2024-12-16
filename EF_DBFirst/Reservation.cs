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
    
    public partial class Reservation
    {
        public int id { get; set; }
        public int RoomId { get; set; }
        public int CustomerId { get; set; }
        public System.DateTime CheckInDate { get; set; }
        public System.DateTime CheckOutDate { get; set; }
        public System.Guid Guid { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public System.DateTime AddedTime { get; set; }
        public int AddedUser { get; set; }
        public string AddedIP { get; set; }
        public System.DateTime UpdatedTime { get; set; }
        public int UpdatedUser { get; set; }
        public string UpdatedIP { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Room Room { get; set; }
    }
}