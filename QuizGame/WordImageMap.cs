using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace QuizGame
{
    public class WordImageMap
    {
        private Dictionary<string, ImageSource> wordImagePairs;

        public WordImageMap()
        {
            wordImagePairs = new Dictionary<string, ImageSource>();
        }

        public void AddWordImagePair(string word, ImageSource imageSource)
        {
            wordImagePairs[word] = imageSource;
        }

        public void ReplaceWordsWithImages(List<string> sentences, TextBlock textBlock)
        {
            textBlock.Inlines.Clear();

            foreach (string sentence in sentences)
            {
                List<Inline> inlines = ReplaceWordsWithImagesInSentence(sentence);

                // Перемешиваем элементы в inlines
                Random random = new Random();
                inlines = inlines.OrderBy(x => random.Next()).ToList();

                // Добавляем элементы в TextBlock.Inlines в перемешанном порядке
                foreach (Inline inline in inlines)
                {
                    textBlock.Inlines.Add(inline);
                }

                textBlock.Inlines.Add(new LineBreak());
            }
        }

        private List<Inline> ReplaceWordsWithImagesInSentence(string sentence)
        {
            string[] words = sentence.Split(' ');
            List<Inline> inlines = new List<Inline>();

            foreach (string word in words)
            {
                if (word.StartsWith("[") && word.EndsWith("]"))
                {
                    string wordWithoutBrackets = word.Trim('[', ']');
                    if (wordImagePairs.TryGetValue(wordWithoutBrackets, out ImageSource imageSource))
                    {
                        Image image = new Image();
                        image.Source = imageSource;

                        InlineUIContainer container = new InlineUIContainer(image);
                        inlines.Add(container);
                    }
                    else
                    {
                        inlines.Add(new Run(word + " "));
                    }
                }
                else
                {
                    inlines.Add(new Run(word + " "));
                }
            }

            return inlines;
        }
    }
}
