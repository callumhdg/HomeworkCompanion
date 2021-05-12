using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeworkCompanion;

namespace BusinessLayer
{
    public class StudentManagement
    {




        public List<Student> SelectAllStudent()
        {
            using (var db = new HomeworkCompanionContext())
            {
                List<Student> output = new List<Student>();
                var allQuestionStudents = db.Students.Select(s => s);

                foreach (var item in allQuestionStudents)
                {
                    output.Add(item);
                }

                return output;
            }
        }

    }
}
