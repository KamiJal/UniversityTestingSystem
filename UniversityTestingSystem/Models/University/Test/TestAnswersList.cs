﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityTestingSystem.Models.University.Test
{
    public class TestAnswersList
    {
        public int Id { get; set; }

        public int CompletedTestId { get; set; }
        public CompletedTest CompletedTest { get; set; }

        public int TestQuestionId { get; set; }
        public TestQuestion TestQuestion { get; set; }

        [Required]
        [StringLength(1)]
        public string Answer { get; set; }
    }
}