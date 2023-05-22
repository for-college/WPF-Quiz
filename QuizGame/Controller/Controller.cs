using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizGame.ViewNamespace;
using QuizGame.ModelNamespace;
using System.Windows.Controls;

namespace QuizGame.Controller
{
    public class Controller
    {
        private Model model;
        private View view;

        public Controller(Model model, View view)
        {
            this.model = model;
            this.view = view;
        }

        public void UpdateDisplay()
        {
            string[] words = model.GetWords();
            Image[] images = model.GetImages();
            int[] indexes = model.GetRandomIndexes();

            view.DisplayText(words, indexes, images);
        }
    }
}
