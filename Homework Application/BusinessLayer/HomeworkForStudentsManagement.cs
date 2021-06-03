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
                var newHomeworkForStudent = new HomeworkForStudent(homeworkID, studentID);
                db.HomeworkForStudents.Add(newHomeworkForStudent);

                db.SaveChanges();
            }
        }

        public List<int> SelectAllHomeworkOfStudent(int studentID)
        {
            using (var db = new HomeworkCompanionContext())
            {
                List<int> output = new List<int>();
                var allStudentHomework =
                    db.HomeworkForStudents
                    .Where(h => h.StudentIdFk == studentID)
                    .Select(h => h.HomeworkIdFk);

                foreach (var item in allStudentHomework)
                {
                    output.Add(item);
                }

                return output;
            }
        }



    }
}
