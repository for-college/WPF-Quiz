using System;
using System.Collections.Generic;
using System.Windows;

namespace QuizGame
{
    public class Controller
    {
        private readonly Model model; // Модель игры
        private readonly WordImageMap wordImageMap; // Карта соответствия слов и изображений
        private readonly View view; // Представление
        public readonly GameStats gameStats; // Статистика игры

        private int iconCount; // Количество иконок

        public Controller(Model model, WordImageMap wordImageMap, View view, int iconCount)
        {
            this.model = model;
            this.wordImageMap = wordImageMap;
            this.view = view;
            this.iconCount = iconCount;

            gameStats = new GameStats
            {
                TotalQuestions = model.GetQuestionCount() // Устанавливаем общее количество вопросов в статистику
            };
        }

        public void AddQuestion(string questionText, string answer)
        {
            model.AddQuestion(questionText, answer); // Добавляем вопрос в модель игры
        }

        public void DisplayCurrentQuestion()
        {
            Question currentQuestion = model.GetCurrentQuestion(); // Получаем текущий вопрос из модели
            if (currentQuestion != null)
            {
                view.SetQuestionText(string.Empty); // Очищаем текст вопроса на представлении

                List<string> sentences = new List<string>
                {
                    currentQuestion.QuestionText
                };

                // Заменяем слово на картинку с использованием карты соответствия
                wordImageMap.ReplaceWordsWithImages(sentences, view.QuestionTextBlock, iconCount);
            }
            else
            {
                OpenEndGameWindow(); // Если вопросы закончились, открываем окно с результатами игры
            }
        }

        public void MoveToNextQuestion()
        {
            model.MoveToNextQuestion(); // Переходим к следующему вопросу в модели
        }

        public void CheckAnswer(string answer)
        {
            Question currentQuestion = model.GetCurrentQuestion(); // Получаем текущий вопрос из модели
            if (currentQuestion != null)
            {
                if (answer.Equals(currentQuestion.Answer, StringComparison.OrdinalIgnoreCase)) // Проверяем ответ игрока
                {
                    gameStats.UpdateCorrectAnswers(); // Обновляем статистику правильных ответов
                }
                MoveToNextQuestion(); // Переходим к следующему вопросу
                DisplayCurrentQuestion(); // Отображаем текущий вопрос
            }
        }

        public void UpdateIconCount(int count)
        {
            iconCount = count; // Обновляем количество иконок
        }

        public void OpenEndGameWindow()
        {
            (int correctAnswers, double percentCorrect) = CalculateResult(); // Вычисляем результаты игры

            bool isWin = percentCorrect >= 50 ? true : false; // Определяем, выиграл ли игрок

            // Создаем окно с итогами игры
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

            return (correctAnswers, percentCorrect); // Возвращаем результаты
        }
    }
}
