using System;
using System.Collections.Generic;

#nullable disable

namespace HomeworkCompanion
{
    public partial class Student
    {
        public Student()
        {
            HomeworkForStudents = new HashSet<HomeworkForStudent>();
            StudentsInClasses = new HashSet<StudentsInClass>();
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }

        public virtual ICollection<HomeworkForStudent> HomeworkForStudents { get; set; }
        public virtual ICollection<StudentsInClass> StudentsInClasses { get; set; }

        public override string ToString()
        {
            return $"{Title} {FirstName} {LastName}";
        }
    }
}
