using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace QuizGame.ModelNamespace
{
    public class Model
    {
        private string[] words;
        private Image[] images;

        public Model(string[] words, Image[] images)
        {
            this.words = words;
            this.images = images;
        }

        public string[] GetWords()
        {
            return words;
        }
        public Image[] GetImages()
        {
            return images;
        }
        public int[] GetRandomIndexes()
        {
            Random random = new Random();

            return Enumerable.Range(0, images.Length).OrderBy(i => random.Next(0, images.Length)).ToArray();
        }
    }
}
