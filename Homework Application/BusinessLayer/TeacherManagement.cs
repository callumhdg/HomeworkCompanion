using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeworkCompanion;

namespace BusinessLayer
{
    public class TeacherManagement
    {

        public Teacher SelectSingleTeacher(int teacherID)
        {
            using (var db = new HomeworkCompanionContext())
            {
                Teacher output = new Teacher();
                var selectedTeacher =
                    db.Teachers
                    .Where(t => t.TeacherId == teacherID)
                    .Select(t => t).FirstOrDefault();

                output = selectedTeacher;
                return output;
            }
        }


        public List<Teacher> SelectAllTeachers()
        {
            using (var db = new HomeworkCompanionContext())
            {
                List<Teacher> output = new List<Teacher>();
                var allQuestionTeachers = db.Teachers.Select(t => t);

                foreach (var item in allQuestionTeachers)
                {
                    output.Add(item);
                }

                return output;
            }
        }
    }
}
