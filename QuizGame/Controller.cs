using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;

namespace QuizGame
{
    public class Controller
    {
        private readonly Model model; // Модель игры
        private readonly WordImageMap wordImageMap; // Карта соответствия слов и изображений
        private readonly View view; // Представление

        public readonly GameStats gameStats; // Статистика игры

        private int iconCount; // Количество иконок
        private TimeSpan countdownTime;
        private DispatcherTimer countdownTimer;

        private bool isFirstQuestionAnswered = false;

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

                if (!isFirstQuestionAnswered)
                {
                    countdownTime = GetCountdownTime(); // Получаем время отсчета в зависимости от количества иконок
                    countdownTimer = new DispatcherTimer
                    {
                        Interval = TimeSpan.FromSeconds(1)
                    };
                    countdownTimer.Tick += CountdownTimer_Tick;
                    countdownTimer.Start(); // Запуск таймера только если ответ на первый вопрос не был дан
                }
            }
            else
            {
                OpenEndGameWindow(); // Если вопросы закончились, открываем окно с результатами игры
            }
        }

        private TimeSpan GetCountdownTime()
        {
            switch (iconCount)
            {
                case 3:
                    return TimeSpan.FromMinutes(3);
                case 4:
                    return TimeSpan.FromMinutes(4);
                case 5:
                    return TimeSpan.FromMinutes(5);
                default:
                    return TimeSpan.FromMinutes(3); // Возвращаем значение по умолчанию
            }
        }

        public void MoveToNextQuestion()
        {
            model.MoveToNextQuestion(); // Переходим к следующему вопросу в модели
            switch (iconCount)
            {
                case 3:
                    countdownTime = TimeSpan.FromMinutes(3);
                    break;
                case 4:
                    countdownTime = TimeSpan.FromMinutes(4);
                    break;
                case 5:
                    countdownTime = TimeSpan.FromMinutes(5);
                    break;
            }
        }

        public void CheckAnswer(string answer)
        {
            if (!isFirstQuestionAnswered)
            {
                isFirstQuestionAnswered = true;
                countdownTimer.Start(); // Запуск таймера только после ответа на первый вопрос
            }

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

            bool isWin = percentCorrect >= 50; // Определяем, выиграл ли игрок

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

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            countdownTime = countdownTime.Subtract(TimeSpan.FromSeconds(1));
            view.SetCountdownText(countdownTime.ToString(@"mm\:ss"));

            if (countdownTime.TotalSeconds <= 0)
            {
                countdownTimer.Stop();
                TimeIsUp(); // Вызываем метод, когда время вышло
            }
        }

        public void TimeIsUp()
        {
            MessageBox.Show("Время вышло!", "Игра окончена", MessageBoxButton.OK, MessageBoxImage.Information);
            Application.Current.Shutdown();
        }
    }
}
