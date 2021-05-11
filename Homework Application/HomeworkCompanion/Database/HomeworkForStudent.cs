using System;
using System.Collections.Generic;

#nullable disable

namespace HomeworkCompanion
{
    public partial class HomeworkForStudent
    {
        public int StudentIdFk { get; set; }
        public int HomeworkIdFk { get; set; }

        public virtual Homework HomeworkIdFkNavigation { get; set; }
        public virtual Student StudentIdFkNavigation { get; set; }
    }
}
