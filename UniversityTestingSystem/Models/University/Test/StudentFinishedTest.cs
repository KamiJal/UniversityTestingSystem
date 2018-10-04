using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityTestingSystem.Models.University.Test
{
    public class StudentFinishedTestAnswer
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        public int TestQuestionId { get; set; }
        public TestQuestion TestQuestion { get; set; }

        [Required]
        [StringLength(1)]
        public string StudentAnswer { get; set; }

    }
}