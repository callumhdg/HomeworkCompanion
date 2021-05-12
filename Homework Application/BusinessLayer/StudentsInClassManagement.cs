using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeworkCompanion;

namespace BusinessLayer
{
    public class StudentsInClassManagement
    {
        public StudentsInClass SelectedStudentsInClass = new StudentsInClass();

        public void AddStudentToClass(int classID, int studentID)
        {
            using (var db = new HomeworkCompanionContext())
            {
                var newStudentInClass = new StudentsInClass() { ClassIdFk = classID, StudentIdFk = studentID };
                db.StudentsInClasses.Add(newStudentInClass);

                db.SaveChanges();
            }
        }

        public void RemoveStudentFromClass(int classID, int studentID)
        {
            using (var db = new HomeworkCompanionContext())
            {
                var studentToRemoveFromClass =
                    db.StudentsInClasses.Where(s => s.ClassIdFk == classID && s.StudentIdFk == studentID)
                    .Select(s => s).FirstOrDefault();

                db.StudentsInClasses.Remove(studentToRemoveFromClass);
                db.SaveChanges();
            }
        }

    }
}
