namespace QuizGame
{
    public class GameStats
    {
        public int TotalQuestions { get; set; }
        public int CorrectAnswers { get; set; }
        public double PercentCorrect => (double)CorrectAnswers / TotalQuestions * 100;

        public void UpdateCorrectAnswers()
        {
            CorrectAnswers++;
        }
    }
}
