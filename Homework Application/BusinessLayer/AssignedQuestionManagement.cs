using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeworkCompanion;

namespace BusinessLayer
{
    public class AssignedQuestionManagement
    {


        public void AssignQuestions(List<QuestionTemplate> questionsToAssign, int homeworkID)
        {
            QuestionTemplateManagement qtManagement = new QuestionTemplateManagement();

            using (var db = new HomeworkCompanionContext())
            {

                foreach (var item in questionsToAssign)
                {
                    QuestionTemplate questionTemplate = qtManagement.SelectSingleQuestionTemplate(item.QuestionId);

                    AssignedQuestion newAssignedQuestion = new AssignedQuestion();

                    newAssignedQuestion.QuestionText = questionTemplate.QuestionText;
                    newAssignedQuestion.TeachersAnswer = questionTemplate.Answer;
                    newAssignedQuestion.MaximumMarks = questionTemplate.MaximumMarks;
                    newAssignedQuestion.HomeworkIdFk = homeworkID;

                    db.AssignedQuestions.Add(newAssignedQuestion);
                }
                db.SaveChanges();
            }

        }





    }
}
