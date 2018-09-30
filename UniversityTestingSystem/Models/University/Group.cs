using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UniversityTestingSystem.Models.Utility;

namespace UniversityTestingSystem.Models.University
{
    public class Group
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredComboBox)]
        [Display(Name = DisplayNames.Group)]
        [StringLength(255, ErrorMessage = ErrorMessages.StringLength255)]
        public string Name { get; set; }
    }
}