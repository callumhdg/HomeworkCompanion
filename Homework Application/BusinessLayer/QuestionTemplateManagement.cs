using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeworkCompanion;

namespace BusinessLayer
{
    public class QuestionTemplateManagement
    {
        public QuestionTemplate SelectedQuestionTemplate { get; set; }
        private IQuestionTemplateService _service;

        public QuestionTemplateManagement()
        {
            _service = new QuestionTemplateService();
        }

        public QuestionTemplateManagement(IQuestionTemplateService service)
        {
            if (service == null)
            {
                throw new ArgumentException("Question Template Service can't be null");
            }
            _service = service;
        }

        public void CreateQuestionTemplate(string questionText, string answer, int maxMarks)
        {
            var newQuestionTemplate = new QuestionTemplate(questionText, answer, maxMarks);
            _service.CreateQuestionTemplate(newQuestionTemplate);
        }


        public bool UpdateQuestionTemplate(int id, string question, string answer, int maxMarks)
        {
            SelectedQuestionTemplate = _service.SelectSingleQuestionTemplate(id);
            if (SelectedQuestionTemplate == null)
            {
                return false;
            }

            SelectedQuestionTemplate.QuestionText = question;
            SelectedQuestionTemplate.Answer = answer;
            SelectedQuestionTemplate.MaximumMarks = maxMarks;

            try
            {
                _service.SaveQuestionTemplateChanges();
            }
            catch (Exception)
            {
                Debug.WriteLine($"Error updating Question Template: {id}");
                return false;
            }

            return true;
        }


        public bool DeleteQuestionTemplate(int id)
        {
            SelectedQuestionTemplate = _service.SelectSingleQuestionTemplate(id);
            if (SelectedQuestionTemplate == null)
            {
                Debug.WriteLine($"Can't find - Question Template: {id}");
                return false;
            }

            _service.DeleteQuestionTemplate(SelectedQuestionTemplate);
            SelectedQuestionTemplate = null;
            return true;

        }


        public List<QuestionTemplate> SelectAllQuestionTemplates()
        {
            return _service.SelectAllQuestionTemplates();       
        }


        public QuestionTemplate SelectSingleQuestionTemplate(int id)
        {
            return _service.SelectSingleQuestionTemplate(id);
        }


    }
}
