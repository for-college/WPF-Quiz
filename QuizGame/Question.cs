using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    public class Question
    {
        // На чешуе жестяной рыбы (картинка) прочёл я зовы новых губ (картинка).
        public string QuestionText { get; set; }
        public string QuestionAnswer { get; set; }
        public bool isAnswered { get; set; }
        
        // public int countPictograms { get; set; }
        // public int difficult { get; set; }

        public Question(string questionText, string questionAnswer)
        {
            QuestionText = questionText;
            QuestionAnswer = questionAnswer;
            isAnswered = false;
        }
    }
}
