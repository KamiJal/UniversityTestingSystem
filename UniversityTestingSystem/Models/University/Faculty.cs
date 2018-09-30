using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UniversityTestingSystem.Models.Utility;

namespace UniversityTestingSystem.Models.University
{
    public class Faculty
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = DisplayNames.Faculty)]
        [StringLength(255, ErrorMessage = ErrorMessages.StringLength255)]
        public string Name { get; set; }
    }
}