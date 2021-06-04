using NUnit.Framework;
using HomeworkCompanion;
using BusinessLayer;
using System.Linq;
using System;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //[Test]
        //public void Test1()
        //{
        //    Assert.Pass();
        //}
    }

    public class Question_Template_Tests
    {
        QuestionTemplateManagement _questionTemplateManager;

        [SetUp]
        public void Setup()
        {
            _questionTemplateManager = new QuestionTemplateManagement();
        }

        [Test]
        public void AddedQuestionTemplateToDatabase()
        {
            using (var db = new HomeworkCompanionContext())
            {
                int before = 0, after = 0;
                before = db.QuestionTemplates.Count();

                _questionTemplateManager.CreateQuestionTemplate("TestData", "TestData", 187);
                after = db.QuestionTemplates.Count();

                Assert.AreEqual(before, after - 1);
            }

        }

        [Test]
        public void UpdatedQuestionTemplate()
        {
            string expectedQuestion = "TestData", actualQuestion = "";
            string expectedAnswer = "TestData", actualAnswer = "";
            int expectedMaxMarks = 187, actualMaxMarks = 0;

            using (var db = new HomeworkCompanionContext())
            {
                var newQuestionTemplate = new QuestionTemplate("example123", "example123", 201);
                db.QuestionTemplates.Add(newQuestionTemplate);
                db.SaveChanges();

                var questionTemplateToUpdate =
                    db.QuestionTemplates.Where(q => q.QuestionText == "example123" && q.Answer == "example123" && q.MaximumMarks == 201)
                    .Select(q => q.QuestionId).FirstOrDefault();

                _questionTemplateManager.UpdateQuestionTemplate(questionTemplateToUpdate, "TestData", "TestData", 187);
            }

            using (var db = new HomeworkCompanionContext())
            {
                var updatedQuestionTemplate =
                    db.QuestionTemplates.Where(q => q.QuestionText == "TestData" && q.Answer == "TestData" && q.MaximumMarks == 187)
                    .Select(q => q).FirstOrDefault();

                actualQuestion = updatedQuestionTemplate.QuestionText;
                actualAnswer = updatedQuestionTemplate.Answer;
                actualMaxMarks = updatedQuestionTemplate.MaximumMarks;
            }

            Assert.AreEqual(expectedQuestion, actualQuestion);
            Assert.AreEqual(expectedAnswer, actualAnswer);
            Assert.AreEqual(expectedMaxMarks, actualMaxMarks);
        }


        [Test]
        public void DeletedQuestionTemplateIsRemovedFromDatabase()
        {
            using (var db = new HomeworkCompanionContext())
            {
                int before = 0, after = 0;
                
                var newQuestionTemplate = new QuestionTemplate("example111", "example111", 101);
                db.QuestionTemplates.Add(newQuestionTemplate);
                db.SaveChanges();

                before = db.QuestionTemplates.Count();

                var QuestionTemplateToDelete =
                db.QuestionTemplates.Where(q => q.QuestionText == "example111" && q.Answer == "example111" && q.MaximumMarks == 101)
                .Select(q => q.QuestionId).FirstOrDefault();

                _questionTemplateManager.DeleteQuestionTemplate(QuestionTemplateToDelete);
                after = db.QuestionTemplates.Count();

                Assert.AreEqual(before, after + 1);
            }            
        }


        [TearDown]
        public void TearDownQuestionTemplateTests()
        {
            using (var db = new HomeworkCompanionContext())
            {
                var questionTemplateToDelete =
                    from q in db.QuestionTemplates
                    where q.QuestionText == "TestData" && q.Answer == "TestData" && q.MaximumMarks == 187
                    select q;

                db.QuestionTemplates.RemoveRange(questionTemplateToDelete);

                db.SaveChanges();
            }
        }

    }


    public class Students_In_Class_Tests
    {
        StudentsInClassManagement studentsInClassManagement;

        [SetUp]
        public void Setup()
        {
            studentsInClassManagement = new StudentsInClassManagement();

            //create dummy class

            //create dummy student


        }

        [Ignore("Not Implemented")]
        [Test]
        public void StudentIsAddedToClass()
        {
            throw new NotImplementedException();
        }


        [Ignore("Not Implemented")]
        [Test]
        public void StudentIsRemovedFromClass()
        {
            throw new NotImplementedException();
        }


        [TearDown]
        public void TearDownStudentsInClassTests()
        {

        }



    }


}