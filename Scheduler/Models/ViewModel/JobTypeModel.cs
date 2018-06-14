using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Scheduler.Models.ViewModel
{


    public class JobTypeModelView
    {

        [Key]
        public Guid ID { get; set; }
        public int Duration { get; set; }
        public string Unit { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Rate")]
        public double Rate { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "SkillRequired")]
        public string SkillRequired { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Workers Required")]
        public int WorkersRequired { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Tools")]
        public string Tools { get; set; }
        [Display(Name = "Tools Cost")]
        public decimal ToolsCost { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Facilities Required")]
        public string FacilitiesRequired { get; set; }
        [Display(Name = "Facilities Cost")]
        public decimal FacilitiesCost { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "JobPrice")]
        public decimal JobPrice { get; set; }
        public int SYSUserID { get; set; }
        


    }

}