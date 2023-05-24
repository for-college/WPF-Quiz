using System;
using System.Collections.Generic;
using System.Windows;

namespace QuizGame
{
    public class Controller
    {
        private readonly Model model;
        private readonly WordImageMap wordImageMap;
        private readonly View view;
        public readonly GameStats gameStats;

        private int iconCount;

        public Controller(Model model, WordImageMap wordImageMap, View view, int iconCount)
        {
            this.model = model;
            this.wordImageMap = wordImageMap;
            this.view = view;
            this.iconCount = iconCount;

            gameStats = new GameStats
            {
                TotalQuestions = model.GetQuestionCount()
            };
        }

        public void AddQuestion(string questionText, string answer)
        {
            model.AddQuestion(questionText, answer);
        }

        public void DisplayCurrentQuestion()
        {
            Question currentQuestion = model.GetCurrentQuestion();
            if (currentQuestion != null)
            {
                view.SetQuestionText(string.Empty);

                List<string> sentences = new List<string>
                {
                    currentQuestion.QuestionText
                };

                // Заменяем слово на картинку
                wordImageMap.ReplaceWordsWithImages(sentences, view.QuestionTextBlock, iconCount);
            }
            else
            {
                OpenEndGameWindow();
            }
        }

        public void MoveToNextQuestion()
        {
            model.MoveToNextQuestion();
        }

        public void CheckAnswer(string answer)
        {
            Question currentQuestion = model.GetCurrentQuestion();
            if (currentQuestion != null)
            {
                if (answer.Equals(currentQuestion.Answer, StringComparison.OrdinalIgnoreCase))
                {
                    gameStats.UpdateCorrectAnswers();
                }
                MoveToNextQuestion();
                DisplayCurrentQuestion();
            }
        }

        public void UpdateIconCount(int count)
        {
            iconCount = count;
        }

        public void OpenEndGameWindow()
        {
            (int correctAnswers, double percentCorrect) = CalculateResult();

            bool isWin = percentCorrect >= 50 ? true : false;

            // Создаем окно с итогами
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = isWin ? MessageBoxImage.Information : MessageBoxImage.Error;

            MessageBox.Show($"Количество правильных ответов: {correctAnswers}\nПроцент правильных ответов: {percentCorrect:0.00}", $"{(isWin ? "Победа" : "Поражение")}", button, icon);

            // Закрываем текущее окно игры
            Application.Current.Shutdown();
        }

        public (int, double) CalculateResult()
        {
            // Подсчитываем количество правильных ответов
            int correctAnswers = gameStats.CorrectAnswers;

            // Вычисляем процент правильных ответов
            double percentCorrect = (double)correctAnswers / gameStats.TotalQuestions * 100;

            return (correctAnswers, percentCorrect);
        }
    }
}
