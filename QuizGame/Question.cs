using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    public class Question
    {
        public string Text { get; set; }
        public string Answer { get; set; }
        public bool IsAnswered { get; set; }

        public Question(string text, string answer)
        {
            Text = text;
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
