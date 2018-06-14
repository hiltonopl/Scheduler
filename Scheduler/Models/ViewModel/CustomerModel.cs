using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Scheduler.Models.ViewModel
{


    public class CustomerModelView
    {

        [Key]
        public Guid ID { get; set; }
        public string Notes { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }
        public int SYSUserID { get; set; }
      

    }

}
