using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UniversityTestingSystem.Models.University;
using UniversityTestingSystem.Models.Utility;

namespace UniversityTestingSystem.Models.ViewModels
{
    public class StudentFormViewModel
    {
        public string UserId { get; set; }

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

        [Required(ErrorMessage = ErrorMessages.RequiredComboBox)]
        [Display(Name = DisplayNames.Faculty)]
        public int FacultyId { get; set; }

        public List<Group> Groups { get; set; }
        public List<Faculty> Faculties { get; set; }


        public StudentFormViewModel() { }

        public StudentFormViewModel(Student student)
        {
            this.FirstName = student.FirstName;
            this.LastName = student.LastName;
            this.GroupId = student.GroupId;
            this.FacultyId = student.FacultyId;
        }
    }
}