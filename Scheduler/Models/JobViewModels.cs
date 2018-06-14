using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scheduler.Models
{

    public class Worker
    {
        public Worker()
        {
            this.Jobs = new List<Job>();
        }

        [Key]
        public Guid WorkerId { get; set; }
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Worker Name")]
        [StringLength(128, ErrorMessage = "Worker's name can only be 128 characters in length.")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }

       
        public virtual ICollection<Job> Jobs { get; set; }
    }

    public class Job
    {
        public Job()
        {
            this.Workers = new List<Worker>();
        }

        [Key]
        public Guid JobId { get; set; }
        [Key]
       
        [Display(Name = "Job Name")]
        [StringLength(128, ErrorMessage = "Job Name can only be 128 characters in length.")]
        public string Name { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }
    }


    public class Tool
    {
        public Tool()
        {
            this.Jobs = new List<Job>();
        }

        [Key]
        public Guid ToolId { get; set; }
        [Key]

        [Display(Name = "Tool Name")]
        [StringLength(128, ErrorMessage = "Tool Name can only be 128 characters in length.")]
        public string Name { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }



    public class CreateWorkerViewModel
    {
        [Required]
        [Display(Name = "Worker Name")]
        [StringLength(128, ErrorMessage = "Workers name can only be 128 characters in length.")]
        public string Name { get; set; }

        public List<string> JobIds { get; set; }

        [Display(Name = "Jobs")]
        public MultiSelectList Jobs { get; set; }
    }

    // Model inherits the same properties from CreatePlayerViewModel, with addition of Id
    public class EditWorkerViewModel : CreateWorkerViewModel
    {
        // Note that this is a string - not a Guid. We can convert this to a Guid in the controller
        public string WorkerId { get; set; }
    }


    public class ListJobViewModel
    {
        [Required]
        [Display(Name = "Job Name")]
        [StringLength(128, ErrorMessage = "Jobs name can only be 128 characters in length.")]
        public string Name { get; set; }
        public string JobId { get; set; }
        public string thisdate { get; set; }
        public string thistimeslot { get; set; }
        public List<string> WorkerIds { get; set; }

        [Display(Name = "Workers")]
        public ICollection<Worker> Workers { get; set; }
        public ICollection<JobBlock> JobBlocks { get; set; }
        public List<string> JobIds { get; set; }
        [Display(Name = "Jobs")]
        public ICollection<Job> Jobs { get; set; }

        public List<string> ToolIds { get; set; }
        [Display(Name = "Tools")]
        public ICollection<Tool> Tools { get; set; }
        public ICollection<JobWorker> JobWorkers { get; set; }
        public ICollection<JobTool> JobTools { get; set; }
        public ICollection<JobType> JobType { get; set; }
        public ICollection<PaymentType> PaymentType { get; set; }
        public ICollection<PaymentMethod> PaymentMethod { get; set; }
    }


    public class CreateJobViewModel
    {
        [Required]
        [Display(Name = "Job Name")]
        [StringLength(128, ErrorMessage = "Jobs name can only be 128 characters in length.")]
        public string Name { get; set; }


        public List<string> WorkerIds { get; set; }

        [Display(Name = "Workers")]
        public MultiSelectList Workers { get; set; }

        public MultiSelectList JobIds { get; set; }
        [Display(Name = "Jobs")]
        public MultiSelectList Jobs { get; set; }

        public List<string> ToolIds { get; set; }
        [Display(Name = "Tools")]
        public MultiSelectList Tools { get; set; }
    }


    // Model inherits the same properties from CreatePlayerViewModel, with addition of Id
    public class EditJobViewModel : CreateJobViewModel
    {
        // Note that this is a string - not a Guid. We can convert this to a Guid in the controller
        public string JobId { get; set; }
    }

    public class PaymentType
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }

    public class PaymentMethod
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }
}


