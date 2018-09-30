using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityTestingSystem.Models.University;

namespace UniversityTestingSystem.Models.ViewModels
{
    public class StudentFormViewModel
    {
        public Student Student { get; set; }
        public List<Group> Groups { get; set; }
        public List<Faculty> Faculties { get; set; }
    }
}