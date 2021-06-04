using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HomeworkCompanion;
using BusinessLayer;

namespace UnitTests
{
    public class QuestionTemplatesServiceTests
    {
        private QuestionTemplateService _sut;
        private HomeworkCompanionContext _context;

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<HomeworkCompanionContext>().UseInMemoryDatabase(databaseName: "HomeworkCompanionDB").Options;
            _context = new HomeworkCompanionContext(options);
            _sut = new QuestionTemplateService(_context);

            _sut.CreateQuestionTemplate(new QuestionTemplate("3 - 1", "2", 1));
            _sut.CreateQuestionTemplate(new QuestionTemplate("8 - 1", "7", 1));
            _sut.CreateQuestionTemplate(new QuestionTemplate("30 - 1", "29", 2));
        }

        [Test]
        public void GivenANewQuestionTemplate_CreateQuestionTemplateAddsQuestionTemplateToTheDatabase()
        {
            int beforeAdding = _context.QuestionTemplates.Count();
            var newQuestionTemplate = new QuestionTemplate("100 - 10", "90", 2);
            _sut.CreateQuestionTemplate(newQuestionTemplate);

            int afterAdding = _context.QuestionTemplates.Count();
            Assert.That(beforeAdding, Is.EqualTo(afterAdding - 1));

            //cleanup 
            _context.QuestionTemplates.Remove(newQuestionTemplate);
            _context.SaveChanges();
        }


        [Test]
        public void GivenAQuestionTemplate_UpdateQuestionTemplateUpdatesTheQuestionTemplate()
        {
            var originalQuestionTemplate = _sut.SelectSingleQuestionTemplate(1);//should select newly created qt from setup
            var originalQuestionText = originalQuestionTemplate.QuestionText;
            var originalAnswer = originalQuestionTemplate.Answer;
            var originalMaxMarks = originalQuestionTemplate.MaximumMarks;

            _sut.UpdateQuestionTemplate(1, "88 - 8", "80", 6);
            var updatedQuestionText = originalQuestionTemplate.QuestionText;
            var updatedAnswer = originalQuestionTemplate.Answer;
            var updatedMaxMarks = originalQuestionTemplate.MaximumMarks;

            Assert.That(updatedQuestionText, Is.Not.EqualTo(originalQuestionText));
            Assert.That(updatedQuestionText, Is.EqualTo("88 - 8"));

            Assert.That(updatedAnswer, Is.Not.EqualTo(originalAnswer));
            Assert.That(updatedAnswer, Is.EqualTo("80"));

            Assert.That(updatedMaxMarks, Is.Not.EqualTo(originalMaxMarks));
            Assert.That(updatedMaxMarks, Is.EqualTo(6));
        }


        [Test]
        public void GivenAQuestionTemplate_DeleteQuestionTemplateDeletesTheQuestionTemplate()
        {
            var beforeDeleting = _context.QuestionTemplates.Count();

            var questionTemplateToDelete = _sut.SelectSingleQuestionTemplate(2);//should select qt from setup
            _sut.DeleteQuestionTemplate(questionTemplateToDelete);

            var afterDeleting = _context.QuestionTemplates.Count();
            Assert.That(beforeDeleting, Is.EqualTo(afterDeleting + 1));

        }


        [Test]
        public void SelectingAllQuestionTemplates_SelectsAllQuestionTemplates()
        {
            int expected = _context.QuestionTemplates.Count();
            var allQuestionTemplates = _sut.SelectAllQuestionTemplates();
            int actual = allQuestionTemplates.Count();

            Assert.That(expected, Is.EqualTo(actual));
        }


        [Test]
        public void SelectingASingleQuestionTemplate_ReturnsTheCorrectQuestionTemplate()
        {
            var expectedQuestionText = "30 - 1";
            var expectedAnswer = "29";
            var expectedMaxMarks = 2;
            
            var selectedQuestionTemplate = _sut.SelectSingleQuestionTemplate(3);
            var actualQuestionText = selectedQuestionTemplate.QuestionText;
            var actualAnswer = selectedQuestionTemplate.Answer;
            var actualMaxMarks = selectedQuestionTemplate.MaximumMarks;

            Assert.That(actualQuestionText, Is.EqualTo(expectedQuestionText));
            Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
            Assert.That(actualMaxMarks, Is.EqualTo(expectedMaxMarks));
        }



    }
}
