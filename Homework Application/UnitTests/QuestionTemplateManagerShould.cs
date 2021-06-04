using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HomeworkCompanion;
using BusinessLayer;
using NUnit.Framework;
using Moq;

namespace UnitTests
{
    public class QuestionTemplateManagerShould
    {
        private QuestionTemplateManagement _sut;

        [OneTimeSetUp]
        public void Setup()
        {
            var mockQuestionTemplateService = new Mock<IQuestionTemplateService>();
            _sut = new QuestionTemplateManagement(mockQuestionTemplateService.Object);
            _sut.CreateQuestionTemplate("3 - 1", "2", 1);
            _sut.CreateQuestionTemplate("8 - 1", "7", 1);
        }


        [Test]
        public void BeAbleToConstruct_QuestionTemplateManagement()
        {
            var mockQuestionTemplateService = new Mock<IQuestionTemplateService>();
            _sut = new QuestionTemplateManagement(mockQuestionTemplateService.Object);
            Assert.That(_sut, Is.InstanceOf<QuestionTemplateManagement>());
        }


        [Test]
        public void GivenAValidId_UpdateQuestionTemplateWill_ReturnTrue()
        {
            var mockQuestionTemplateService = new Mock<IQuestionTemplateService>();
            var originalQuestionTemplate = new QuestionTemplate("64 - 32", "32", 2) { QuestionId = 100 };

            mockQuestionTemplateService.Setup(qt => qt.SelectSingleQuestionTemplate(100)).Returns(originalQuestionTemplate);
            _sut = new QuestionTemplateManagement(mockQuestionTemplateService.Object);

            var result = _sut.UpdateQuestionTemplate(100, "64 / 4", "16", 4);
            Assert.That(result, Is.True);
        }

        [Test]
        public void GivenAnInvalidId_UpdateQuestionTemplateWill_ReturnFalse()
        {
            var mockQuestionTemplateService = new Mock<IQuestionTemplateService>();
            mockQuestionTemplateService.Setup(qt => qt.SelectSingleQuestionTemplate(-1));
            
            _sut = new QuestionTemplateManagement(mockQuestionTemplateService.Object);
            var result = _sut.UpdateQuestionTemplate(-1, "64 / 4", "16", 4);

            Assert.That(result, Is.False);
        }

        [Test]
        public void GivenAnInvalidQuestionTemplateId_DeleteQuestionTemplateWill_ReturnFalse()
        {
            var mockQuestionTemplateService = new Mock<IQuestionTemplateService>();
            _sut = new QuestionTemplateManagement(mockQuestionTemplateService.Object);

            var result = _sut.DeleteQuestionTemplate(-1);

            Assert.That(result, Is.False);
        }

        [Test]
        public void GivenAValidQuestionTemplateId_DeleteQuestionTemplateWill_ReturnTrue()
        {
            var mockQuestionTemplateService = new Mock<IQuestionTemplateService>();
            _sut = new QuestionTemplateManagement(mockQuestionTemplateService.Object);

            var result = _sut.DeleteQuestionTemplate();

            Assert.That(result, Is.True);
        }


    }
}
