using System;
using System.Collections.Generic;

#nullable disable

namespace HomeworkCompanion
{
    public partial class AssignedQuestion
    {
        public AssignedQuestion(string questionText, string submitedAnswer, string teachersAnswer, int maximumMarks)
        {
            QuestionText = questionText;
            SubmitedAnswer = submitedAnswer;
            TeachersAnswer = teachersAnswer;
            MaximumMarks = maximumMarks;
        }

        public int AssignedQuestionId { get; set; }
        public int HomeworkIdFk { get; set; }
        public string QuestionText { get; set; }
        public string SubmitedAnswer { get; set; }
        public string TeachersAnswer { get; set; }
        public int MaximumMarks { get; set; }
        public int? AwardedMarks { get; set; }

        public virtual Homework HomeworkIdFkNavigation { get; set; }
    }
}
