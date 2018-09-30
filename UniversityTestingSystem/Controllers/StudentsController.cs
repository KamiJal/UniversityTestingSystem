using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Entity;
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
            if (disposing)
            {
                _context.Dispose();
            }
        }


        // GET: students/form        
        public ActionResult StudentForm()
        {
            var currentUserId = User.Identity.GetUserId();

            var student = _context.Students.SingleOrDefault(s => s.UserId.Equals(currentUserId));

            if (student != null && student.IsFormFilled)
                return RedirectToAction("StudentProfile");

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
            if (!ModelState.IsValid || !User.Identity.GetUserId().Equals(student.UserId))
            {
                var viewModel = new StudentFormViewModel(student)
                {
                    Faculties = _context.Faculties.ToList(),
                    Groups = _context.Groups.ToList()
                };

                return View("StudentForm", viewModel);
            }

            student.IsFormFilled = true;

            _context.Students.Add(student);

            try
            {
                _context.SaveChanges();
            }
            catch (SqlException ex)
            {
                return View("ErrorDb", ex.Errors);
            }

            return RedirectToAction("StudentProfile");
        }

        public ActionResult StudentProfile()
        {
            var currentUserId = User.Identity.GetUserId();
            var currentStudent = _context.Students
                .Include(s => s.Faculty)
                .Include(s => s.Group)
                .Single(s => s.UserId.Equals(currentUserId));


            return View(currentStudent);
        }

    }
}