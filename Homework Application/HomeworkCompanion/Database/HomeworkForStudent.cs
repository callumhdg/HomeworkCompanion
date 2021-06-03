using System;
using System.Collections.Generic;

#nullable disable

namespace HomeworkCompanion
{
    public partial class HomeworkForStudent
    {
        public HomeworkForStudent(int studentIdFk, int homeworkIdFk)
        {
            StudentIdFk = studentIdFk;
            HomeworkIdFk = homeworkIdFk;
        }

        public int StudentIdFk { get; set; }
        public int HomeworkIdFk { get; set; }

        public virtual Homework HomeworkIdFkNavigation { get; set; }
        public virtual Student StudentIdFkNavigation { get; set; }
    }
}
