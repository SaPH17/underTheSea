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
    
    public partial class RestaurantTransaction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RestaurantTransaction()
        {
            this.DetailRestaurantTransaction = new HashSet<DetailRestaurantTransaction>();
        }
    
        public int transactionID { get; set; }
        public Nullable<int> employeeID { get; set; }
        public Nullable<int> seatID { get; set; }
        public Nullable<System.DateTime> purchaseDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailRestaurantTransaction> DetailRestaurantTransaction { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Seat Seat { get; set; }
    }
}