using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SODING_INDIVIDUAL_ASSIGNMENT.ViewModel
{
    public class TaskVM
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Task Name")]
        public string TaskName { get; set; }
    }
}