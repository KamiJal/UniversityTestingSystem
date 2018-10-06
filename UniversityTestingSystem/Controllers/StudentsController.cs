using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using UniversityTestingSystem.Models;
using UniversityTestingSystem.Models.University;
using UniversityTestingSystem.Models.University.Test;
using UniversityTestingSystem.Models.Utility;
using UniversityTestingSystem.Models.ViewModels;

namespace UniversityTestingSystem.Controllers
{

    [Authorize(Roles = RoleNames.Student)]
    public class StudentsController : Controller
    {
        //readonly dbContext to access the Db
        private readonly ApplicationDbContext _context;

        //constructor initialize dbContext
        public StudentsController()
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

        // GET: /Students/StudentProfile
        //student profile where student can get all required information
        public ActionResult StudentProfile()
        {
            CurrentUserData.UserId = User.Identity.GetUserId();

            CurrentUserData.Student = _context.Students
                .Include(s => s.Faculty)
                .Include(s => s.Group)
                .SingleOrDefault(s => s.UserId.Equals(CurrentUserData.UserId));

            if (CurrentUserData.Student == null)
            {
                return RedirectToAction("StudentForm", "Students");
            }

            var viewModel = new StudentProfileViewModel()
            {
                Student = CurrentUserData.Student,
                CompletedTests = _context.CompletedTests
                    .Include(q => q.Test)
                    .Include(q => q.Test.Subject)
                    .Where(q => q.StudentId == CurrentUserData.Student.Id).ToList(),

                ScheduledTests = _context.ScheduledTests
                    .Include(q => q.Test)
                    .Include(q => q.Test.Subject)
                    .Where(q => q.StudentId == CurrentUserData.Student.Id && q.IsCompleted == false).ToList()
            };

            return View(viewModel);
        }

        // GET: /Students/StudentForm
        //form to fill by new user
        public ActionResult StudentForm()
        {
            var viewModel = new StudentFormViewModel()
            {
                UserId = User.Identity.GetUserId(),
                Login = User.Identity.Name,
                Faculties = _context.Faculties.ToList(),
                Groups = _context.Groups.ToList()
            };

            return View("StudentForm", viewModel);
        }

        // POST: /Students/Create
        //creates new student by filled data in the form
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

            _context.Students.Add(student);
            SaveChangesToDbSafe();

            return RedirectToAction("StudentProfile");
        }

        // POST: /Students/StartTest/{int id}
        //starts test by id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StartTest(int id)
        {
            CurrentUserData.ScheduledTest = _context.ScheduledTests.SingleOrDefault(q => q.Id == id);

            if (CurrentUserData.ScheduledTest == null || CurrentUserData.ScheduledTest.StudentId != CurrentUserData.Student.Id)
                return View("Error");

            if (!_context.Tests.Any(q => q.Id == CurrentUserData.ScheduledTest.TestId))
                return View("Error");

            CurrentUserData.Test = _context.Tests.Single(t => t.Id == CurrentUserData.ScheduledTest.TestId);

            CurrentUserData.TestQuestions = _context.TestQuestions
                .Where(tq => tq.TestId == CurrentUserData.Test.Id)
                .ToList();

            CurrentUserData.QuestionIterator = 0;

            var completedTest = new CompletedTest
            {
                StudentId = CurrentUserData.Student.Id,
                TestId = CurrentUserData.Test.Id,
                CompletedDate = DateTime.Now
            };

            _context.CompletedTests.Add(completedTest);

            SaveChangesToDbSafe();

            CurrentUserData.CompletedTestId = completedTest.Id;

            return RedirectToAction("TestOnAir");
        }

        // GET: /Students/TestOnAir
        //Iterates through the test questions
        public ActionResult TestOnAir()
        {
            if (CurrentUserData.QuestionIterator == 15)
            {
                CalculateTestResult();
                return View("TestCompleted", (object)CurrentUserData.Test.Name);
            }

            var viewModel = CurrentUserData.GetTestQuestionViewModel();
            return View("TestQuestion", viewModel);
        }

        //Calculates Correct Test Answers
        private void CalculateTestResult()
        {
            short points = 0;

            var userAnswers = _context.TestAnswersLists
                .Where(q => q.CompletedTestId == CurrentUserData.CompletedTestId).ToList();

            foreach (var userAnswer in userAnswers)
            {
                if (CurrentUserData.TestQuestions
                    .Exists(q => q.Id == userAnswer.TestQuestionId && q.CorrectAnswer.Equals(userAnswer.Answer)))
                    points++;
            }

            var completedTestInDb = _context.CompletedTests.Single(q => q.Id == CurrentUserData.CompletedTestId);
            completedTestInDb.Points = points;

            var scheduledTestInDb = _context.ScheduledTests.Single(q => q.Id == CurrentUserData.ScheduledTest.Id);
            scheduledTestInDb.IsCompleted = true;

           SaveChangesToDbSafe();
        }

        // POST: /Students/RecordAnswer{int QuestionId, string Answer}
        //saves answer to db
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RecordAnswer(TestAnswerViewModel response)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = CurrentUserData.GetTestQuestionViewModel();
                return View("TestQuestion", viewModel);
            }

            var testAnswer = new TestAnswersList
            {
                CompletedTestId = CurrentUserData.CompletedTestId,
                TestQuestionId = response.QuestionId,
                Answer = response.Answer
            };

            _context.TestAnswersLists.Add(testAnswer);
            SaveChangesToDbSafe();

            CurrentUserData.QuestionIterator++;

            return RedirectToAction("TestOnAir");
        }




    }
}