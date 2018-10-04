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
using UniversityTestingSystem.Models.University.Test;
using UniversityTestingSystem.Models.ViewModels;

namespace UniversityTestingSystem.Controllers
{

    [Authorize]
    public class StudentsController : Controller
    {
        private ApplicationDbContext _context;

        private static List<TestQuestion> currentTestQuestions;
        private static int currentTestQuestionId;

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

        public ActionResult StudentProfile()
        {
            var currentUserId = User.Identity.GetUserId();

            var currentStudent = _context.Students
                .Include(s => s.Faculty)
                .Include(s => s.Group)
                .SingleOrDefault(s => s.UserId.Equals(currentUserId));

            if (currentStudent == null)
            {
                return RedirectToAction("StudentForm", "Students");
            }

            return View(currentStudent);
        }

        // GET: students/form        
        public ActionResult StudentForm()
        {
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


        public ActionResult StartTest(int id)
        {
            currentTestQuestions = _context.TestQuestions.Include(tq => tq.Test).Where(tq => tq.TestId == id).ToList();
            currentTestQuestionId = 0;

            return RedirectToAction("TestOnAir");
        }

        public ActionResult TestOnAir()
        {
            if (currentTestQuestionId == 15)
            {
                return RedirectToAction("StudentProfile");
            }

            TestQuestion current = currentTestQuestions.ElementAt(currentTestQuestionId);
            var viewModel = new TestQuestionViewModel(current, currentTestQuestionId);

            return View("TestQuestion", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RecordAnswer(TestAnswerViewModel response)
        {
            if (!ModelState.IsValid)
            {
                TestQuestion current = currentTestQuestions.ElementAt(response.CurrentQuestionId);
                var viewModel = new TestQuestionViewModel(current, response.CurrentQuestionId);
                return View("TestQuestion", viewModel);
            }

            currentTestQuestionId++;

            return RedirectToAction("TestOnAir");
        }

    }
}