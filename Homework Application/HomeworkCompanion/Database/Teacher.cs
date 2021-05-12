using System;
using System.Collections.Generic;

#nullable disable

namespace HomeworkCompanion
{
    public partial class Teacher
    {
        public Teacher()
        {
            Classes = new HashSet<Class>();
        }

        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Class> Classes { get; set; }

        public override string ToString()
        {
            return $"{Title} {FirstName} {LastName}";
        }
    }
}
