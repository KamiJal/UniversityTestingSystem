using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using UniversityTestingSystem.Models;
using UniversityTestingSystem.Models.University;
using UniversityTestingSystem.Models.University.Test;
using UniversityTestingSystem.Models.Utility;
using UniversityTestingSystem.Models.ViewModels;

namespace UniversityTestingSystem.Controllers
{

    [Authorize]
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

            var viewModel = new StudentProfileViewModel
            {
                Student = CurrentUserData.Student,
                FinishedTests = _context.FinishedTests.Include(q => q.Test)
                    .Where(q => q.StudentId == CurrentUserData.Student.Id).Select(q => q.Test).ToList()
            };

            return View(viewModel);
        }

        // GET: /Students/StudentForm
        //form to fill by new user
        public ActionResult StudentForm()
        {
            var viewModel = new StudentFormViewModel
            {
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

        // GET: /Students/StartTest/{int id}
        //starts test by id
        public ActionResult StartTest(int id)
        {
            if (!_context.Tests.Any(t => t.Id == id))
                return View("Error");

            CurrentUserData.Test = _context.Tests.Single(t => t.Id == id);

            CurrentUserData.TestQuestions = _context.TestQuestions
                .Where(tq => tq.TestId == id)
                .ToList();

            CurrentUserData.QuestionIterator = 0;

            var test = new FinishedTest
            {
                StudentId = CurrentUserData.Student.Id,
                TestId = CurrentUserData.Test.Id,
                FinishedDate = DateTime.Now
            };

            _context.FinishedTests.Add(test);
            SaveChangesToDbSafe();

            CurrentUserData.FinishedTestId = test.Id;

            return RedirectToAction("TestOnAir");
        }

        // GET: /Students/TestOnAir
        //Iterates through the test questions
        public ActionResult TestOnAir()
        {
            if (CurrentUserData.QuestionIterator == 15)
            {
                CalculateTestResult();
                return View("TestFinished", CurrentUserData.Test.Name);
            }

            var viewModel = CurrentUserData.GetTestQuestionViewModel();
            return View("TestQuestion", viewModel);
        }

        //Calculates Correct Test Answers
        private void CalculateTestResult()
        {
            short points = 0;

            var userAnswers = _context.TestAnswersLists
                .Where(q => q.FinishedTestId == CurrentUserData.FinishedTestId).ToList();

            foreach (var userAnswer in userAnswers)
            {
                if (CurrentUserData.TestQuestions
                    .Exists(q => q.Id == userAnswer.TestQuestionId && q.CorrectAnswer.Equals(userAnswer.Answer)))
                    points++;
            }

            var finishedTestInDb = _context.FinishedTests.Single(q => q.Id == CurrentUserData.FinishedTestId);
            finishedTestInDb.Points = points;

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
                FinishedTestId = CurrentUserData.FinishedTestId,
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