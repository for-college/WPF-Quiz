using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace QuizGame.ViewNamespace
{
    public class View
    {
        private TextBlock textBlock;

        public View(TextBlock textBlock)
        {
            this.textBlock = textBlock;
        }

        public void DisplayText(string[] words, int[] indexes, Image[] images)
        {
            textBlock.Inlines.Clear();
            foreach(string word in words)
            {
                if (word.StartsWith("img"))
                {
                    int imageIndex = indexes[int.Parse(word.Substring(3))];
                    Image image = images[imageIndex];

                    textBlock.Inlines.Add(image);
                }
                else
                {
                    textBlock.Inlines.Add(word);
                }
            }
        }
    }
}
