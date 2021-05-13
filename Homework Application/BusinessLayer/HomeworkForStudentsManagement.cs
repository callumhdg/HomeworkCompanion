using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeworkCompanion;

namespace BusinessLayer
{
    public class HomeworkForStudentsManagement
    {

        public void AssignHomeworkToStudent(int homeworkID, int studentID)
        {
            using (var db = new HomeworkCompanionContext())
            {
                var newHomeworkForStudent = new HomeworkForStudent() { HomeworkIdFk = homeworkID, StudentIdFk = studentID };
                db.HomeworkForStudents.Add(newHomeworkForStudent);

                db.SaveChanges();
            }
        }

        

    }
}
