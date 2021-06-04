using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkCompanion
{
    public interface IQuestionTemplateService
    {
        public void CreateQuestionTemplate(QuestionTemplate newQuestionTemplate);
        public void UpdateQuestionTemplate(int id, string question, string answer, int maxMarks);
        public void DeleteQuestionTemplate(QuestionTemplate qt);
        public List<QuestionTemplate> SelectAllQuestionTemplates();
        public QuestionTemplate SelectSingleQuestionTemplate(int id);
        public void SaveQuestionTemplateChanges();

    }
}
