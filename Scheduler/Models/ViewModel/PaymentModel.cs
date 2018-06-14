using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Scheduler.Models.EntityManager;

namespace Scheduler.Models.ViewModel
{


    public class PaymentModelView
    {
       
        [Key]
        public System.Guid ID { get; set; }
        [Display(Name = "Receipt Number")]
        public string ReceiptNo { get; set; }
        public Nullable<decimal> Payment1 { get; set; }
        [Display(Name = "Payment Date")]
        public Nullable<System.DateTime> PaymentDate { get; set; }
        [Display(Name = "Job")]
        public Nullable<System.Guid> JobID { get; set; }
        [Display(Name = "Reference")]
        public string Reference { get; set; }
        [Display(Name = "Payment Type")]
        public string PaymentType { get; set; }
        [Display(Name = "Collected By")]
        public string CollectedBy { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<int> InvoiceID { get; set; }
        public Nullable<System.Guid> PaymentTypeID { get; set; }
        public Nullable<int> PaymentMethodId { get; set; }

    }

   
}


