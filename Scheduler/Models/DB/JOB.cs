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
    
    public partial class JOB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JOB()
        {
            this.INVOICEs = new HashSet<INVOICE>();
            this.TOOLs = new HashSet<TOOL>();
        }
    
        public System.Guid ID { get; set; }
        public Nullable<System.Guid> JobTypeID { get; set; }
        public Nullable<System.Guid> BlockID { get; set; }
        public Nullable<int> WorkerID { get; set; }
        public Nullable<System.Guid> CustomerID { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<int> ToolID { get; set; }
        public Nullable<int> MarketerID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVOICE> INVOICEs { get; set; }
        public virtual SYSUserProfile SYSUserProfile { get; set; }
        public virtual TOOL TOOL { get; set; }
        public virtual SYSUserProfile SYSUserProfile1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TOOL> TOOLs { get; set; }
    }
}
