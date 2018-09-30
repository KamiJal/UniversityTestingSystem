using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;
using UniversityTestingSystem.Models.Utility;

namespace UniversityTestingSystem.Models.University
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredTextBox)]
        [Display(Name = DisplayNames.FirstName)]
        [StringLength(255, ErrorMessage = ErrorMessages.StringLength255)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredTextBox)]
        [Display(Name = DisplayNames.LastName)]
        [StringLength(255, ErrorMessage = ErrorMessages.StringLength255)]
        public string LastName { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredComboBox)]
        [Display(Name = DisplayNames.Group)]
        public int GroupId { get; set; }

        public Group Group { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredComboBox)]
        [Display(Name = DisplayNames.Faculty)]
        public int FacultyId { get; set; }

        public Faculty Faculty { get; set; }

        public bool IsFormFilled { get; set; } = false;
    }
}