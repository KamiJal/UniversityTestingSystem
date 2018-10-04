using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UniversityTestingSystem.Models.Utility;

namespace UniversityTestingSystem.Models.University.Test
{
    public class TestQuestion
    {
        public int Id { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = ErrorMessages.StringLength255)]
        public string Question { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = ErrorMessages.StringLength255)]
        public string AnswerA { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = ErrorMessages.StringLength255)]
        public string AnswerB { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = ErrorMessages.StringLength255)]
        public string AnswerC { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = ErrorMessages.StringLength255)]
        public string AnswerD { get; set; }

        [Required]
        [StringLength(1, ErrorMessage = ErrorMessages.StringLength255)]
        public string CorrectAnswer { get; set; }
    }
}