using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeworkCompanion;

namespace BusinessLayer
{
    public class HomeworkManagement
    {

        public void AssignHomework(int studentID, string title, DateTime dueDate, List<QuestionTemplate> selectedQuestions)
        {
            using (var db = new HomeworkCompanionContext())
            {
                var newHomework = new Homework() { Title = title, DueDate = dueDate };
                db.Homeworks.Add(newHomework);

                db.SaveChanges();
            }

            HomeworkForStudentsManagement _homeworkForStudentsManagement = new HomeworkForStudentsManagement();
            AssignedQuestionManagement _assignedQuestionManagement = new AssignedQuestionManagement();

            using (var db = new HomeworkCompanionContext())
            {
                var allHomeworkIDs = db.Homeworks.Select(h => h.HomeworkId);

                int mostRecentHomework = allHomeworkIDs.Max(); //should return the highest ID value in the homework table, highest being most recent

                _homeworkForStudentsManagement.AssignHomeworkToStudent(mostRecentHomework, studentID);//create link

                _assignedQuestionManagement.AssignQuestions(selectedQuestions, mostRecentHomework);//create assigned questiuons
            }
            
        }


        public void AssignClassHomework(int classID, string title, DateTime dueDate, List<QuestionTemplate> selectedQuestions)
        {
            StudentManagement _studentManagement = new StudentManagement();
            List<Student> studentsToReciveHomework = new List<Student>();

            studentsToReciveHomework = _studentManagement.SelectAllStudentsInAClass(classID);

            foreach (var item in studentsToReciveHomework)
            {
                AssignHomework(item.StudentId, title, dueDate, selectedQuestions);
            }

        }


        public List<Homework> SelectStudentsHomework(int studentID)
        {
            using (var db = new HomeworkCompanionContext())
            {
                List<Homework> output = new List<Homework>();
                List<Homework> allHomeworkOfStudent = new List<Homework>();

                HomeworkForStudentsManagement hfsManager = new HomeworkForStudentsManagement();
                List<int> studentsHomeworkIDs = new List<int>();

                studentsHomeworkIDs = hfsManager.SelectAllHomeworkOfStudent(studentID);

                HomeworkManagement _homeworkManagement = new HomeworkManagement();
                foreach (var item in studentsHomeworkIDs)
                {
                    output.Add(_homeworkManagement.SelectSingleHomework(item));
                }

                return output;
            }
        }


        public Homework SelectSingleHomework(int id)
        {
            using (var db = new HomeworkCompanionContext())
            {                
                var selectHomework =
                    db.Homeworks
                    .Where(h => h.HomeworkId == id)
                    .Select(h => h).FirstOrDefault();
                var output = selectHomework;

                return output;
            }
        }


        public List<Homework> SelectDueHomework(int studentID)
        {
            using (var db = new HomeworkCompanionContext())
            {
                HomeworkManagement _homeworkManagement = new HomeworkManagement();
                List<Homework> output = new List<Homework>();
                List<Homework> allStudentHomework = new List<Homework>();

                allStudentHomework = _homeworkManagement.SelectStudentsHomework(studentID);

                foreach (var item in allStudentHomework)
                {
                    int isDue = DateTime.Compare(item.DueDate, DateTime.UtcNow);

                    if (isDue >= 0 && item.SubmissionDate == null)
                    {
                        output.Add(item);
                    }
                }

                return output;
            }
        } 



    }
}
