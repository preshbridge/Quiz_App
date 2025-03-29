using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizApp.Models;
using QuizApp.Services;

namespace QuizApp.Tests
{
    [TestClass]
    public class QuizServiceTests
    {
        private QuizService _quizService;

        [TestInitialize]
        public void Setup()
        {
            _quizService = new QuizService();
        }

        [TestMethod]
        public void GetQuizzes_ShouldReturnNonEmptyList()
        {
            var quizzes = _quizService.GetQuizzes();
            Assert.IsTrue(quizzes.Count > 0, "The quiz list should not be empty.");
        }

        [TestMethod]
        public void Quiz_ShouldHaveQuestions()
        {
            var quizzes = _quizService.GetQuizzes();
            foreach (var quiz in quizzes)
            {
                Assert.IsTrue(quiz.Questions.Count > 0, $"The quiz '{quiz.Title}' should have at least one question.");
            }
        }

        [TestMethod]
        public void Questions_ShouldHaveOptions()
        {
            var quizzes = _quizService.GetQuizzes();
            foreach (var quiz in quizzes)
            {
                foreach (var question in quiz.Questions)
                {
                    Assert.IsTrue(question.Options.Count > 0, $"The question '{question.Text}' should have at least one option.");
                }
            }
        }

        [TestMethod]
        public void Questions_ShouldHaveCorrectOptionIndex()
        {
            var quizzes = _quizService.GetQuizzes();
            foreach (var quiz in quizzes)
            {
                foreach (var question in quiz.Questions)
                {
                    Assert.IsTrue(question.CorrectOptionIndex >= 0 && question.CorrectOptionIndex < question.Options.Count, $"The question '{question.Text}' should have a valid CorrectOptionIndex.");
                }
            }
        }
    }
}
