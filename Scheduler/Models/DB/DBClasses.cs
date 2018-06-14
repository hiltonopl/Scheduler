namespace Scheduler.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public partial class  JOBDISPLAY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JOBDISPLAY()
        {
           
            this.WORKERs = new List<SYSUserProfile>().Where(s => s.UserTypeID.Equals(1)).ToList();
            this.MARKETERs = new List<SYSUserProfile>().Where(s => s.UserTypeID.Equals(2)).ToList();
            this.TOOLs = new List<TOOL>();
            this.JOBs = new List<JOB>();
        }

        public string Address { get; set; }
        public string Notes { get; set; }

      
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TOOL> TOOLs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYSUserProfile> WORKERs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYSUserProfile> MARKETERs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYSUserProfile> SYSUserProfiles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JOB> JOBs { get; set; }
    }


    
//public partial class  TOOL
//{
//    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
//    public TOOL()
//    {
             
//    }

//    public string Address { get; set; }
//    public string Notes { get; set; }


 
//    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//    public virtual ICollection<JOB> JOBs { get; set; }
//}
}




