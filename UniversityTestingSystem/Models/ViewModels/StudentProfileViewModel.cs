using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityTestingSystem.Models.University;
using UniversityTestingSystem.Models.University.Test;

namespace UniversityTestingSystem.Models.ViewModels
{
    public class StudentProfileViewModel
    {
        public Student Student { get; set; }
        public List<Test> FinishedTests { get; set; }
    }
}