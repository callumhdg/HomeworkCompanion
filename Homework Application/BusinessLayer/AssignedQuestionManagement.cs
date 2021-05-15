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
        public AssignedQuestion SelectedQuestion { get; set; }
        public Homework SelectedHomework { get; set; }

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

        public List<AssignedQuestion> SelectAllQuestionsInHomework(int homeworkID)
        {
            using (var db = new HomeworkCompanionContext())
            {
                List<AssignedQuestion> output = new List<AssignedQuestion>();

                var selectQuestionsInHomework =
                    db.AssignedQuestions
                    .Where(q => q.HomeworkIdFk == homeworkID)
                    .Select(q => q);

                foreach (var item in selectQuestionsInHomework)
                {
                    output.Add(item);
                }

                return output; //returns answer as max marks
            }
        }


        public void SaveDraftHomework(List<AssignedQuestion> draft)
        {
            using (var db = new HomeworkCompanionContext())
            {
                foreach (var item in draft)
                {
                    UpdateAssignedQuestionAnswer(item);
                }

                db.SaveChanges();
            }
        }


        public void SubmitHomework(List<AssignedQuestion> submission)
        {
            using (var db = new HomeworkCompanionContext())
            {
                SaveDraftHomework(submission);

                SelectedHomework = db.Homeworks.Find(submission[0].HomeworkIdFk);
                SelectedHomework.SubmissionDate = DateTime.UtcNow;

                db.SaveChanges();
            }
        }


        public void UpdateAssignedQuestionAnswer(AssignedQuestion updateQuestion)
        {
            using (var db = new HomeworkCompanionContext())
            {
                SelectedQuestion = db.AssignedQuestions.Find(updateQuestion.AssignedQuestionId);

                SelectedQuestion.SubmitedAnswer = updateQuestion.SubmitedAnswer;

                db.SaveChanges();
            }
        }


        public void AssignMarksToQuestion(int questionID, int awardedMark)
        {
            using (var db = new HomeworkCompanionContext())
            {
                SelectedQuestion = db.AssignedQuestions.Find(questionID);

                SelectedQuestion.AwardedMarks = awardedMark;

                db.SaveChanges();
            }
        }


    }
}
