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
    
    public partial class HRRequest
    {
        public int requestID { get; set; }
        public Nullable<int> employeeID { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string response { get; set; }
        public string status { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
