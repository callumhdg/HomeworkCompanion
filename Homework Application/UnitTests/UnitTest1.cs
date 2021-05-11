using NUnit.Framework;
using HomeworkCompanion;
using BusinessLayer;
using System.Linq;

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
        public void QuestionTemplateIsAddedToDatabase()
        {
            using (var db = new HomeworkCompanionContext())
            {
                int before = 0, after = 0;
                before = db.QuestionTemplates.Count();

                _questionTemplateManager.CreateQuestionTemplate("3 + 5", "8", 1);
                after = db.QuestionTemplates.Count();

                Assert.AreEqual(before, after - 1);
            }

        }

        [TearDown]
        public void TearDownQuestionTemplateTests()
        {
            using (var db = new HomeworkCompanionContext())
            {
                var questionTemplateToDelete =
                    from q in db.QuestionTemplates
                    where q.QuestionText == "3 + 5" && q.Answer == "8" && q.MaximumMarks == 1
                    select q;

                db.QuestionTemplates.RemoveRange(questionTemplateToDelete);



                db.SaveChanges();
            }
        }

    }


}