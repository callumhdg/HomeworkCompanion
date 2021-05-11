using System;
using System.Collections.Generic;

#nullable disable

namespace HomeworkCompanion
{
    public partial class StudentsInClass
    {
        public int StudentIdFk { get; set; }
        public int ClassIdFk { get; set; }

        public virtual Class ClassIdFkNavigation { get; set; }
        public virtual Student StudentIdFkNavigation { get; set; }
    }
}
