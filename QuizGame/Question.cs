namespace QuizGame
{
    public class Question
    {
        public string QuestionText { get; set; }
        public string Answer { get; set; }
        public bool IsAnswered { get; set; }

        public Question(string questionText, string answer)
        {
            QuestionText = questionText;
            Answer = answer;
            IsAnswered = false;
        }

        public void MarkAsAnswered()
        {
            IsAnswered = true;
        }

        public void MarkAsUnanswered()
        {
            IsAnswered = false;
        }

        public bool GetIsAnswered()
        {
            return IsAnswered;
        }
    }
}

