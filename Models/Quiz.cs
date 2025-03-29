using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    /// <summary>
    /// Represents a quiz.
    /// </summary>
    public class Quiz
    {
        /// <summary>
        /// Gets or sets the title of the quiz.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the list of questions in the quiz.
        /// </summary>
        public List<Question> Questions { get; set; }
    }

    /// <summary>
    /// Represents a question in a quiz.
    /// </summary>
    public class Question
    {
        /// <summary>
        /// Gets or sets the text of the question.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the list of answer options for the question.
        /// </summary>
        public List<AnswerOption> Options { get; set; }

        /// <summary>
        /// Gets or sets the index of the correct answer option.
        /// </summary>
        public int CorrectOptionIndex { get; set; }

        /// <summary>
        /// Gets or sets the score weight of the question.
        /// </summary>
        public int ScoreWeight { get; set; }
    }

    /// <summary>
    /// Represents an answer option for a question.
    /// </summary>
    public class AnswerOption
    {
        /// <summary>
        /// Gets or sets the text of the answer option.
        /// </summary>
        public string Text { get; set; }
    }
}

