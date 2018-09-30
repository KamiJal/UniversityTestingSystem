using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityTestingSystem.Models;
using UniversityTestingSystem.Models.University;
using UniversityTestingSystem.Models.ViewModels;

namespace UniversityTestingSystem.Controllers
{

    public class StudentsController : Controller
    {
        private ApplicationDbContext _context;

        public StudentsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: students/form        
        public ActionResult Form()
        {
            var viewModel = new StudentViewModel
            {
                Faculties = new List<Faculty>
                {
                    new Faculty {Code = "JOU", Id = 1, Name = "Журналистика" },
                    new Faculty {Code = "TRA", Id = 2, Name = "Переводческое дело" },
                    new Faculty {Code = "PSY", Id = 3, Name = "Психология" },
                    new Faculty {Code = "TOU", Id = 4, Name = "Туризм" },
                },

                Groups = new List<Group>
                {
                    new Group {Id = 1, FacultyId = 1, Name = "101"},
                    new Group {Id = 2, FacultyId = 1, Name = "102"},
                    new Group {Id = 2, FacultyId = 1, Name = "103"},
                    new Group {Id = 2, FacultyId = 1, Name = "104"},
                    new Group {Id = 2, FacultyId = 1, Name = "105"}
                 }
            };

            return View("StudentForm", viewModel);
        }
    }
}