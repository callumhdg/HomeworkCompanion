using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkCompanion
{
    public class QuestionTemplateService : IQuestionTemplateService
    {
        private readonly HomeworkCompanionContext _context;

        public QuestionTemplateService(HomeworkCompanionContext context)
        {
            _context = context;
        }

        public QuestionTemplateService()
        {
            _context = new HomeworkCompanionContext();
        }

        public void CreateQuestionTemplate(QuestionTemplate newQuestionTemplate)
        {
            //QuestionTemplate newQuestionTemplate = new QuestionTemplate() { QuestionText = questionText, Answer = answer, MaximumMarks = maxMarks };
            _context.QuestionTemplates.Add(newQuestionTemplate);
            _context.SaveChanges();
        }

        public void DeleteQuestionTemplate(QuestionTemplate qt)
        {
            _context.QuestionTemplates.Remove(qt);
            _context.SaveChanges();
        }

        public List<QuestionTemplate> SelectAllQuestionTemplates()
        {
            return _context.QuestionTemplates.Select(qt => qt).ToList<QuestionTemplate>();
        }

        public QuestionTemplate SelectSingleQuestionTemplate(int id)
        { 
            return _context.QuestionTemplates.Find(id);
        }

        public void UpdateQuestionTemplate(int id, string question, string answer, int maxMarks)
        {
            var questionTemplateToUpdate = _context.QuestionTemplates.Find(id);
            questionTemplateToUpdate.QuestionText = question;
            questionTemplateToUpdate.Answer = answer;
            questionTemplateToUpdate.MaximumMarks = maxMarks;
            _context.SaveChanges();
        }

        public void SaveQuestionTemplateChanges()
        {
            _context.SaveChanges();
        }

    }
}
