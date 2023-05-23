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

        private int iconCount;

        public Controller(Model model, WordImageMap wordImageMap, View view, int iconCount)
        {
            this.model = model;
            this.wordImageMap = wordImageMap;
            this.view = view;
            this.iconCount = iconCount;
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

                // Pass the iconCount to ReplaceWordsWithImages method
                wordImageMap.ReplaceWordsWithImages(sentences, view.QuestionTextBlock, iconCount);
            }
            else
            {
                // TODO: Доделать логику
                view.SetQuestionText("Вопросов не осталось");
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

        public void UpdateIconCount(int count)
        {
            iconCount = count;
        }


        private void CalculateResult()
        {
            // TODO: Расчет итогового результата
        }
    }
}
