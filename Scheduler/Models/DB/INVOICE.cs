//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Scheduler.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class INVOICE
    {
        public System.Guid ID { get; set; }
        public string InvoiceNumber { get; set; }
        public Nullable<System.Guid> JobID { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<int> CustomerID { get; set; }
    
        public virtual JOB JOB { get; set; }
    }
}
