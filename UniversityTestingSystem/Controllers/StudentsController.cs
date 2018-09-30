using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using UniversityTestingSystem.Models;
using UniversityTestingSystem.Models.University;
using UniversityTestingSystem.Models.ViewModels;

namespace UniversityTestingSystem.Controllers
{

    [Authorize]
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
            var student = _context.Students.SingleOrDefault(s => s.UserId.Equals(User.Identity.GetUserId()));

            if (student.IsFormFilled)
                return RedirectToAction("Profile");

            var viewModel = new StudentFormViewModel
            {
                Faculties = _context.Faculties.ToList(),
                Groups = _context.Groups.ToList()
            };

            return View("StudentForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new StudentFormViewModel
                {
                    Student = student,
                    Faculties = _context.Faculties.ToList(),
                    Groups = _context.Groups.ToList()
                };

                return View("StudentForm", viewModel);
            }

            student.UserId = User.Identity.GetUserId();

            _context.Students.Add(student);

            try
            {
                _context.SaveChanges();
            }
            catch (SqlException ex)
            {
                return View("ErrorDb", ex.Errors);
            }

            return RedirectToAction("Profile");
        }
    }
}