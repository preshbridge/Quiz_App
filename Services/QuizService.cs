using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizApp.Models;

namespace QuizApp.Services
{
    /// <summary>
    /// Represents the Quiz Service class.
    /// </summary>
    public class QuizService
    {
        /// <summary>
        /// Represents the function to Get all the quizzes available on the platform
        /// </summary>
        public List<Quiz> GetQuizzes()
        {
            return new List<Quiz>
            {
                new Quiz
                {
                    Title = "Biology",
                    Questions = new List<Question>
                    {
                        new Question
                        {
                            Text = "What is the full meaning of DNA?",
                            Options = new List<AnswerOption>
                            {
                                new AnswerOption { Text = "Dinucleotide Adenosine" },
                                new AnswerOption { Text = " Deoxyribo nucleic Acid" },
                                new AnswerOption { Text = "DoubleNitrogenous Acid" },
                                new AnswerOption { Text = "Ribonucleic Acid" }
                            },
                            CorrectOptionIndex = 2,
                            ScoreWeight = 6
                        },
                        new Question
                        {
                            Text = " What is the meaning of photosynthesis?",
                            Options = new List<AnswerOption>
                            {
                                new AnswerOption { Text = "The process by which animals convert food into energy" },
                                new AnswerOption { Text = "The breakdown of glucose to release energy in cells" },
                                new AnswerOption { Text = "The process by which plants use sunlight to make food" },
                                new AnswerOption { Text = "The absorption of water by plant roots" }
                            },
                            CorrectOptionIndex = 4,
                            ScoreWeight = 4
                        }
                    }
                },

                 new Quiz
                {
                    Title = "English",
                    Questions = new List<Question>
                    {
                        new Question
                        {
                            Text = "Which word means to run quickly?",
                            Options = new List<AnswerOption>
                            {
                                new AnswerOption { Text = "Walk" },
                                new AnswerOption { Text = "Crawl" },
                                new AnswerOption { Text = "Sprint" },
                                new AnswerOption { Text = "I don't know" }
                            },
                            CorrectOptionIndex = 3,
                            ScoreWeight = 5
                        },
                        new Question
                        {
                            Text = "Which sentence correctly uses a comma?",
                            Options = new List<AnswerOption>
                            {
                                new AnswerOption { Text = "I like pizza burgers and fries" },
                                new AnswerOption { Text = "I like pizza, burgers, and fries" },
                                new AnswerOption { Text = "I like pizza burgers, and fries." },
                                new AnswerOption { Text = "I like pizza burgers and, fries" }
                            },
                            CorrectOptionIndex = 2,
                            ScoreWeight = 4
                        }
                    }
                }
            };
        }
    }
}
