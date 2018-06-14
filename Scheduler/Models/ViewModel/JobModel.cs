using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Scheduler.Models.EntityManager;

namespace Scheduler.Models.ViewModel
{
 

    public class JobModelView
    {

        [Key]
        public Guid ID { get; set; }
        public Guid JobTypeID { get; set; }
        public Guid BlockID { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Customer ID")]
        public Guid CustomerID { get; set; }
        
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Cost")]
        public decimal Cost { get; set; }
        public int SYSUserID { get; set; }
        [Display(Name = "Customer")]
        public JobCustomer JobCustomer { get; set; }
        [Display(Name = "Job Type")]
        public IEnumerable<JobType> JobType { get; set; }
        
    }

    public class ToolModelView
    {
        [Required(ErrorMessage = "*")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Type")]
        public string Type { get; set; }
        [Display(Name = "Unit Cost")]
        public Nullable<decimal> UnitCost { get; set; }
        [Display(Name = "Unit")]
        public string Unit { get; set; }
        [Key]
        public int ID { get; set; }
        public Nullable<System.Guid> JobID { get; set; }
        public Nullable<System.Guid> GUIDID { get; set; }

    }



}


public class JobCustomer
{

  
    public string SelectedCustomer { get; set; }
    public IEnumerable<Customer> Customer { get; set; }
}

public class JobWorker
{
    public string JobId { get; set; }
    public string WorkerId { get; set; }
    public string Worker { get; set; }
}

public class JobTool
{

    public string JobId { get; set; }
    public string ToolId { get; set; }
    public string Tool { get; set; }
}


public class Customer
{
    public string Text { get; set; }
    public Guid Value { get; set; }
}


public class JobType
{
    public string Text { get; set; }
    public Guid Value { get; set; }
    public double Rate { get; set; }
    public int Duration { get; set; }
    public string Unit { get; set; }
    public string SkillsRequired { get; set; }
    public int WorkersRequired { get; set; }
    public string Tools { get; set; }
    public double FacilitiesCost { get; set; }
    public double ToolsCost { get; set; }
    public string FacilitiesRequired { get; set; }
    public double JobPrice { get; set; }
}


public class Assignment
{

    public string JobId { get; set; }
    public string AssignmentId { get; set; }
    public string AssignmentType { get; set; }
    
}

public class JobBlock
{
   
   public string JobId { get; set; }
   public string Date { get; set; }
   public string TimeSlot { get; set; }
   


    
}