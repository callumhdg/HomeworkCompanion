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


        public void UpdateQuestionTemplate()
        {
            throw new NotImplementedException();
        }


        public void DeleteQuestionTemplate()
        {
            throw new NotImplementedException();
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



    }
}
