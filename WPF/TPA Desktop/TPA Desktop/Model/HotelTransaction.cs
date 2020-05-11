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
    
    public partial class HotelTransaction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HotelTransaction()
        {
            this.DetailHotelTransaction = new HashSet<DetailHotelTransaction>();
        }
    
        public int transactionID { get; set; }
        public Nullable<int> customerID { get; set; }
        public Nullable<int> employeeID { get; set; }
        public Nullable<System.DateTime> purchaseDate { get; set; }
    
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailHotelTransaction> DetailHotelTransaction { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
