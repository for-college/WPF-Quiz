﻿namespace QuizGame
{
    public class Question
    {
        public string QuestionText { get; set; } // Текст вопроса
        public string Answer { get; set; } // Ответ на вопрос
        public bool IsAnswered { get; set; } // Флаг, указывающий, был ли данный вопрос отвечен

        public Question(string questionText, string answer)
        {
            QuestionText = questionText; // Установка текста вопроса
            Answer = answer; // Установка ответа на вопрос
            IsAnswered = false; // По умолчанию вопрос не отвечен
        }

        public void MarkAsAnswered()
        {
            IsAnswered = true; // Установка флага "отвечен"
        }

        public void MarkAsUnanswered()
        {
            IsAnswered = false; // Установка флага "не отвечен"
        }

        public bool GetIsAnswered()
        {
            return IsAnswered; // Возвращает значение флага "отвечен"
        }
    }
}
