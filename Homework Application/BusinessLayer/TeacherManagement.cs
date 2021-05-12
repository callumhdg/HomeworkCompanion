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
