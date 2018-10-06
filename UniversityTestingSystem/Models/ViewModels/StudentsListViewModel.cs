using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityTestingSystem.Models.University;
using UniversityTestingSystem.Models.University.Test;

namespace UniversityTestingSystem.Models.ViewModels
{
    public class StudentsListViewModel
    {
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<CompletedTest> CompletedTests { get; set; }
        public IEnumerable<ScheduledTest> ScheduledTests { get; set; }
    }
}