using QuizApp.Models;
using QuizApp.Services;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace QuizApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private QuizService _quizService;
        private List<Quiz> _quizzes;
        private Quiz _currentQuiz;
        private int _currentQuestionIndex;
        private int _score;
        private int _selectedOptionIndex;

        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            _quizService = new QuizService();
            LoadQuizzes();
        }

        /// <summary>
        /// Loads the list of quizzes from the QuizService.
        /// </summary>
        private void LoadQuizzes()
        {
            _quizzes = _quizService.GetQuizzes();
            foreach (var quiz in _quizzes)
            {
                QuizSelectionComboBox.Items.Add(quiz.Title);
            }
        }

        /// <summary>
        /// Handles the Click event of the StartQuizButton. Starts the selected quiz.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The RoutedEventArgs instance containing the event data.</param>
        private void StartQuizButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (QuizSelectionComboBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a quiz.");
                    return;
                }

                _currentQuiz = _quizzes[QuizSelectionComboBox.SelectedIndex];
                _currentQuestionIndex = 0;
                _score = 0;
                StartQuiz();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Starts the quiz and displays the first question
        /// </summary>
        private void StartQuiz()
        {
            QuizPanel.Visibility = Visibility.Visible;
            ScoreTextBlock.Visibility = Visibility.Collapsed;
            RetakeQuizButton.Visibility = Visibility.Collapsed;
            DisplayQuestion();
        }

        /// <summary>
        /// Displays the current question and its answer options.
        /// </summary>
        private void DisplayQuestion()
        {
            var currentQuestion = _currentQuiz.Questions[_currentQuestionIndex];
            QuestionTextBlock.Text = currentQuestion.Text;
            AnswerOptionsPanel.Children.Clear();
            _selectedOptionIndex = -1;

            for (int i = 0; i < currentQuestion.Options.Count; i++)
            {
                var radioButton = new RadioButton
                {
                    Content = currentQuestion.Options[i].Text,
                    GroupName = "AnswerOptions",
                    Tag = i
                };
                radioButton.Checked += RadioButton_Checked;
                AnswerOptionsPanel.Children.Add(radioButton);
            }
        }

        /// <summary>
        /// Handles the Checked event of the RadioButton controls. Sets the selected answer index.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The RoutedEventArgs instance containing the event data.</param>
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            _selectedOptionIndex = (int)radioButton.Tag;
        }

        /// <summary>
        /// Handles the Click event of the ConfirmButton. Confirms the selected answer, provides feedback, and moves to the next question.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The RoutedEventArgs instance containing the event data.</param>
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_selectedOptionIndex == -1)
                {
                    MessageBox.Show("Please select an answer.");
                    return;
                }

                var result = MessageBox.Show("Are you sure about your answer?", "Confirm Answer", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var currentQuestion = _currentQuiz.Questions[_currentQuestionIndex];
                    if (_selectedOptionIndex == currentQuestion.CorrectOptionIndex)
                    {
                        _score += currentQuestion.ScoreWeight;
                        MessageBox.Show("Correct!");
                    }
                    else
                    {
                        MessageBox.Show("Wrong!");
                    }

                    _currentQuestionIndex++;
                    if (_currentQuestionIndex < _currentQuiz.Questions.Count)
                    {
                        DisplayQuestion();
                    }
                    else
                    {
                        EndQuiz();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Ends the quiz and displays the user's score.
        /// </summary>
        private void EndQuiz()
        {
            int totalScoreWeight = 0;
            foreach (var question in _currentQuiz.Questions)
            {
                totalScoreWeight += question.ScoreWeight;
            }
            double percentageScore = (_score / (double)totalScoreWeight) * 100;
            QuizPanel.Visibility = Visibility.Collapsed;
            ScoreTextBlock.Visibility = Visibility.Visible;
            RetakeQuizButton.Visibility = Visibility.Visible;
            ScoreTextBlock.Text = $"Your score: {_score}/{totalScoreWeight} = {percentageScore}%";
        }

        /// <summary>
        /// Handles the Click event of the RetakeQuizButton. Resets the quiz and starts it again.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The RoutedEventArgs instance containing the event data.</param>
        private void RetakeQuizButton_Click(object sender, RoutedEventArgs e)
        {
            _currentQuestionIndex = 0;
            _score = 0;
            StartQuiz();
        }

        /// <summary>
        /// Handles the SelectionChanged event of the QuizSelectionComboBox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The SelectionChangedEventArgs instance containing the event data.</param>
        private void QuizSelectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            QuizPanel.Visibility = Visibility.Collapsed;
            ScoreTextBlock.Visibility = Visibility.Collapsed;
            RetakeQuizButton.Visibility = Visibility.Collapsed ;
            AnswerOptionsPanel.Children.Clear();
            _selectedOptionIndex = -1;
            _score = 0;
        }
    }
}
