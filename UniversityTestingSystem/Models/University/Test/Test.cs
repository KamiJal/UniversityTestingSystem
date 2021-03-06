﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityTestingSystem.Models.University.Test
{
    public class Test
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime AddedDate { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}