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
                //Faculties = new List<Faculty>
                //{
                //    new Faculty {Code = "JOU", Id = 1, Name = "Журналистика" },
                //    new Faculty {Code = "TRA", Id = 2, Name = "Переводческое дело" },
                //    new Faculty {Code = "PSY", Id = 3, Name = "Психология" },
                //    new Faculty {Code = "TOU", Id = 4, Name = "Туризм" },
                //},

                Faculties = _context.Faculties.ToList(),
                Groups = _context.Groups.ToList()
            };

            return View("StudentForm", viewModel);
        }
    }
}