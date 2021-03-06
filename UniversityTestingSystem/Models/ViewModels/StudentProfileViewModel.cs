﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UniversityTestingSystem.Models.University;
using UniversityTestingSystem.Models.University.Test;
using UniversityTestingSystem.Models.Utility;

namespace UniversityTestingSystem.Models.ViewModels
{
    public class StudentProfileViewModel
    {
        public Student Student { get; set; }

        public StudentFormViewModel StudentFormViewModel { get; set; }

        public IEnumerable<Test> Tests { get; set; }
        public IEnumerable<CompletedTest> CompletedTests { get; set; }
        public IEnumerable<ScheduledTest> ScheduledTests { get; set; }
    }
}