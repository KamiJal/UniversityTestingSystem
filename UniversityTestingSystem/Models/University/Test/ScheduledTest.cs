using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityTestingSystem.Models.University.Test
{
    public class ScheduledTest
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        public DateTime AssignedDate { get; set; }

        public bool IsCompleted { get; set; } = false;
    }
}