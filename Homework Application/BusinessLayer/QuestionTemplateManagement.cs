using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeworkCompanion;

namespace BusinessLayer
{
    public class QuestionTemplateManagement
    {
        public QuestionTemplate SelectedQuestionTemplate { get; set; }

        public void CreateQuestionTemplate(string questionText, string answer, int maxMarks)
        {
            var newQuestionTemplate = new QuestionTemplate() { QuestionText = questionText, Answer = answer, MaximumMarks = maxMarks };
            using (var db = new HomeworkCompanionContext())
            {
                db.QuestionTemplates.Add(newQuestionTemplate);
                db.SaveChanges();
            }
        }


        public void UpdateQuestionTemplate(int id, string question, string answer, int maxMarks)
        {
            using (var db = new HomeworkCompanionContext())
            {
                SelectedQuestionTemplate = db.QuestionTemplates.Find(id);

                SelectedQuestionTemplate.QuestionText = question;
                SelectedQuestionTemplate.Answer = answer;
                SelectedQuestionTemplate.MaximumMarks = maxMarks;

                db.SaveChanges();
            }
        }


        public void DeleteQuestionTemplate(int id)
        {
            using (var db = new HomeworkCompanionContext())
            {
                var questionTemplateToDelete = db.QuestionTemplates.Find(id);
                db.QuestionTemplates.Remove(questionTemplateToDelete);
                db.SaveChanges();
            }
        }


        public List<QuestionTemplate> SelectAllQuestionTemplates()
        {
            using (var db = new HomeworkCompanionContext())
            {
                List<QuestionTemplate> output = new List<QuestionTemplate>();
                var allQuestionTemplates = db.QuestionTemplates.Select(q => q);

                foreach (var item in allQuestionTemplates)
                {
                    output.Add(item);
                }

                return output;
            }            
        }


        public QuestionTemplate SelectSingleQuestionTemplate(int id)
        {
            using (var db = new HomeworkCompanionContext())
            {
                var selectQuestion = db.QuestionTemplates
                    .Where(q => q.QuestionId == id)
                    .Select(q => q).FirstOrDefault();

                return selectQuestion;
            }
        }


    }
}
