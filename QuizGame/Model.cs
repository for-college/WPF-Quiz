using System.Collections.Generic;

namespace QuizGame
{
    public class Model
    {
        private List<Question> questions;
        private int currentQuestionIndex;

        public Model()
        {
            questions = new List<Question>();
            currentQuestionIndex = 0;
        }

        public void AddQuestion(string questionText, string answer)
        {
            Question question = new Question(questionText, answer);
            questions.Add(question);
        }

        public Question GetCurrentQuestion()
        {
            if (currentQuestionIndex < questions.Count)
            {
                return questions[currentQuestionIndex];
            }
            return null;
        }

        public void MoveToNextQuestion()
        {
            currentQuestionIndex++;
        }
    }
}

