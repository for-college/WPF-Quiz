using System;
using System.Collections.Generic;
using System.Windows;

namespace QuizGame
{
    public class Controller
    {
        private readonly Model model;
        private readonly WordImageMap wordImageMap;
        private readonly MainWindow view;

        public Controller(Model model, WordImageMap wordImageMap, MainWindow view)
        {
            this.model = model;
            this.wordImageMap = wordImageMap;
            this.view = view;
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
                view.QuestionTextBlock.Text = string.Empty;

                List<string> sentences = new List<string>
                {
                    currentQuestion.QuestionText
                };
                wordImageMap.ReplaceWordsWithImages(sentences, view.QuestionTextBlock);
            }
            else
            {
                // TODO: Доделать логику
                view.QuestionTextBlock.Text = "Вопросов не осталось";
                CalculateResult();
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
                    // TODO: потом это убрать
                    MessageBox.Show("Верный ответ");
                }
                else
                {
                    // TODO: потом это убрать
                    MessageBox.Show("Плохой ответ");
                }
                MoveToNextQuestion();
                DisplayCurrentQuestion();
            }
        }

        private void CalculateResult()
        {
            // TODO: Расчет итогового результата
        }
    }
}

