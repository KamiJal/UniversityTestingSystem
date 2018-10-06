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
        public string TestName { get; set; }

        public int QuestionId { get; set; }
        public string Question { get; set; }
        public int QuestionIterator { get; set; }

        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }

        public TestQuestionViewModel(TestQuestion question)
        {
            QuestionId = question.Id;
            Question = question.Question;
            AnswerA = question.AnswerA;
            AnswerB = question.AnswerB;
            AnswerC = question.AnswerC;
            AnswerD = question.AnswerD;
        }
    }
}