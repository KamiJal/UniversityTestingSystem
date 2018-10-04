using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UniversityTestingSystem.Models.University;
using UniversityTestingSystem.Models.University.Test;

namespace UniversityTestingSystem.Models.ViewModels
{
    public class TestQuestionViewModel
    {
        public int QuestionId { get; set; }

        public int CurrentQuestionId { get; set; }

        public string TestName { get; set; }

        public string Question { get; set; }

        public string AnswerA { get; set; }

        public string AnswerB { get; set; }

        public string AnswerC { get; set; }

        public string AnswerD { get; set; }

        [Required]
        public string StudentAnswer { get; set; }

        public TestQuestionViewModel() { }

        public TestQuestionViewModel(TestQuestion current, int currentQuestionId)
        {
            CurrentQuestionId = currentQuestionId;
            QuestionId = current.Id;
            TestName = current.Test.Name;
            Question = current.Question;
            AnswerA = current.AnswerA;
            AnswerB = current.AnswerB;
            AnswerC = current.AnswerC;
            AnswerD = current.AnswerD;
        }
    }
}