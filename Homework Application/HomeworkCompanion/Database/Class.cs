using System;
using System.Collections.Generic;

#nullable disable

namespace HomeworkCompanion
{
    public partial class Class
    {
        public Class()
        {
            StudentsInClasses = new HashSet<StudentsInClass>();
        }

        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassSubject { get; set; }
        public int? ClassTeacherFk { get; set; }

        public virtual Teacher ClassTeacherFkNavigation { get; set; }
        public virtual ICollection<StudentsInClass> StudentsInClasses { get; set; }
    }
}
