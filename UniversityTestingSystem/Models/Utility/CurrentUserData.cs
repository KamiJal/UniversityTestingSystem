using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityTestingSystem.Models.University;
using UniversityTestingSystem.Models.University.Test;
using UniversityTestingSystem.Models.ViewModels;

namespace UniversityTestingSystem.Models.Utility
{
    public static class CurrentUserData
    {
        public static string UserId { get; set; }
        public static Student Student { get; set; }

        public static ScheduledTest ScheduledTest { get; set; }
        public static Test Test { get; set; }
        public static List<TestQuestion> TestQuestions { get; set; }
        public static int QuestionIterator { get; set; }

        public static int CompletedTestId { get; set; }


        public static TestQuestionViewModel GetTestQuestionViewModel()
        {
            if (TestQuestions == null || Test == null)
                return null;

            return new TestQuestionViewModel(TestQuestions.ElementAt(QuestionIterator))
            {
                QuestionIterator = QuestionIterator,
                TestName = Test.Name
            };
        }
    }
}