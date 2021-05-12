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


        public List<Student> SelectAllStudentsInAClass(int classID)
        {
            using (var db = new HomeworkCompanionContext())
            {
                List<Student> output = new List<Student>();
                var allStudentIDsInClass = 
                    db.StudentsInClasses.Where(s => s.ClassIdFk == classID)
                    .Select(s => s.StudentIdFk);

                List<int> studentIDs = new List<int>();

                foreach (var item in allStudentIDsInClass)
                {
                    studentIDs.Add(item);
                }

                for (int i = 0; i < studentIDs.Count; i++)
                {
                    var studentInClass =
                    db.Students.Where(s => s.StudentId == studentIDs[i])
                    .Select(s => s).FirstOrDefault();

                    output.Add(studentInClass);
                }

                return output;
            }
        }


        public List<Student> SelectAllStudentsNotInAClass(int classID)
        {
            using (var db = new HomeworkCompanionContext())
            {
                List<Student> output = new List<Student>();
                var allStudentIDsInClass =
                    db.StudentsInClasses.Where(s => s.ClassIdFk == classID)
                    .Select(s => s.StudentIdFk);

                List<int> studentsInClassIDs = new List<int>();

                foreach (var item in allStudentIDsInClass)
                {
                    studentsInClassIDs.Add(item);
                }


                StudentManagement sm = new StudentManagement();
                List<Student> allStudents = sm.SelectAllStudent();

                for (int i = 0; i < allStudents.Count; i++)
                {
                    bool inClass = false;
                    for (int id = 0; id < studentsInClassIDs.Count; id++)
                    {
                        if (allStudents[i].StudentId == studentsInClassIDs[id])
                        {
                            inClass = true;
                        }
                    }

                    if (inClass == false)
                    {
                        output.Add(allStudents[i]);
                    }

                    if (studentsInClassIDs.Count == 0)
                    {
                        return allStudents;
                    }
                }

                return output;
            }
        }



    }
}
