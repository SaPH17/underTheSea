//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TPA_Desktop.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetailHotelTransaction
    {
        public int transactionID { get; set; }
        public int roomID { get; set; }
        public Nullable<int> duration { get; set; }
    
        public virtual Room Room { get; set; }
        public virtual HotelTransaction HotelTransaction { get; set; }
    }
}