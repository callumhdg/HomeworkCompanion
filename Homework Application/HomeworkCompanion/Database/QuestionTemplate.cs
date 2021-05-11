using System;
using System.Collections.Generic;

#nullable disable

namespace HomeworkCompanion
{
    public partial class QuestionTemplate
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string Answer { get; set; }
        public int MaximumMarks { get; set; }

        public override string ToString()
        {
            return $"Question: {QuestionText} - Answer: {Answer} - Max Marks: {MaximumMarks}";
        }
    }
}
