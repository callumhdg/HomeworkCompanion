using System;
using System.Collections.Generic;

#nullable disable

namespace HomeworkCompanion
{
    public partial class Homework
    {
        public Homework()
        {
            AssignedQuestions = new HashSet<AssignedQuestion>();
            HomeworkForStudents = new HashSet<HomeworkForStudent>();
        }

        public int HomeworkId { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public string Marks { get; set; }

        public virtual ICollection<AssignedQuestion> AssignedQuestions { get; set; }
        public virtual ICollection<HomeworkForStudent> HomeworkForStudents { get; set; }

        public override string ToString()
        {
            return $"{Title} - Due: {DueDate}";
        }

        public string ToStringLong()
        {
            return $"{Title} - Due: {DueDate} - Submited: {SubmissionDate} - Marks: {Marks}";
        }

    }
}
