using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityTestingSystem.Models;
using UniversityTestingSystem.Models.University;
using UniversityTestingSystem.Models.University.Test;
using UniversityTestingSystem.Models.Utility;
using UniversityTestingSystem.Models.ViewModels;

namespace UniversityTestingSystem.Controllers
{
    [Authorize(Roles = RoleNames.Administrator)]
    public class AdminController : Controller
    {
        //readonly dbContext to access the Db
        private readonly ApplicationDbContext _context;

        //constructor initialize dbContext
        public AdminController()
        {
            _context = new ApplicationDbContext();

        }

        //disposes dbContext after use
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        //dbContext save changes wrapped in try-catch
        private void SaveChangesToDbSafe()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (SqlException ex)
            {
                ShowErrorInDb(ex);
            }
        }

        // GET: /Students/ShowErrorInDb
        //shows error messages occured in Db
        public ActionResult ShowErrorInDb(SqlException ex)
        {
            return View("ErrorDb", ex.Errors);
        }

        // GET: Admin
        public ActionResult StudentsList()
        {
            var viewModel = new StudentsListViewModel
            {
                Students = _context.Students.Include(q => q.Faculty).Include(q => q.Group).ToList(),

                CompletedTests = _context.CompletedTests
                .Include(q => q.Test)
                .Include(q => q.Test.Subject).ToList(),

                ScheduledTests = _context.ScheduledTests
                    .Include(q => q.Test)
                    .Include(q => q.Test.Subject)
                    .Where(q => q.IsCompleted == false).ToList()
            };

            return View(viewModel);
        }

        
        public ActionResult StudentProfile(int id)
        {
            var student = _context.Students.Include(q => q.Faculty).Include(q => q.Group)
                .SingleOrDefault(q => q.Id == id);

            if (student == null)
                return View("Error");

            var viewModel = new StudentProfileViewModel
            {
                Student = student,
                StudentFormViewModel = new StudentFormViewModel(student)
                {
                    Faculties = _context.Faculties.ToList(),
                    Groups = _context.Groups.ToList()
                },
                Tests = _context.Tests.Include(q=>q.Subject).ToList(),

                CompletedTests = _context.CompletedTests
                    .Include(q => q.Test)
                    .Include(q => q.Test.Subject)
                    .Where(q => q.StudentId == id).ToList(),

                ScheduledTests = _context.ScheduledTests
                    .Include(q => q.Test)
                    .Include(q => q.Test.Subject)
                    .Where(q => q.StudentId == id && q.IsCompleted == false).ToList()
            };

            return View("StudentProfileEdit", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditStudent(Student student)
        {
            var studentInDb = _context.Students.Single(q => q.Id == student.Id);
            studentInDb.Map(student);

            SaveChangesToDbSafe();

            return Redirect("/Admin/StudentProfile/" + student.Id);
        }

        public ActionResult ScheduleTestToStudent(int studentId, int? testId)
        {
            if (testId != null)
            {
                var scheduledTest = new ScheduledTest
                {
                    StudentId = studentId,
                    TestId = testId.Value,
                    AssignedDate = DateTime.Now
                };

                _context.ScheduledTests.Add(scheduledTest);
                SaveChangesToDbSafe();
            }

            return Redirect("/Admin/StudentProfile/" + studentId);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteScheduledTest(int studentId, int id)
        {

            var scheduledTest = _context.ScheduledTests.SingleOrDefault(q => q.Id == id);

            if (scheduledTest == null)
                return View("Error");

            _context.ScheduledTests.Remove(scheduledTest);

            SaveChangesToDbSafe();
            
            return Redirect("/Admin/StudentProfile/" + studentId);
        }
    }
}