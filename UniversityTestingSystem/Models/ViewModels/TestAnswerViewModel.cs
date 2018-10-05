﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityTestingSystem.Models.ViewModels
{
    public class TestAnswerViewModel
    {
        public int QuestionId { get; set; }

        [Required]
        public string Answer { get; set; }
    }
}