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
        private readonly Dictionary<string, ImageSource> wordImagePairs;

        public WordImageMap()
        {
            wordImagePairs = new Dictionary<string, ImageSource>();
        }

        public void AddWordImagePair(string word, ImageSource imageSource)
        {
            wordImagePairs[word] = imageSource;
        }

        public void ReplaceWordsWithImages(List<string> sentences, TextBlock textBlock, int iconCount)
        {
            textBlock.Inlines.Clear();

            Random random = new Random(); // Create a new instance of Random

            foreach (string sentence in sentences)
            {
                List<Inline> inlines = ReplaceWordsWithImagesInSentence(sentence, iconCount, random);

                // Добавляем элементы в TextBlock.Inlines в перемешанном порядке
                foreach (Inline inline in inlines)
                {
                    textBlock.Inlines.Add(inline);
                }

                textBlock.Inlines.Add(new LineBreak());
            }
        }

        private List<Inline> ReplaceWordsWithImagesInSentence(string sentence, int iconCount, Random random)
        {
            string[] words = sentence.Split(' ');
            List<Inline> inlines = new List<Inline>();
            int totalLength = 0; // Variable to keep track of the total length of the text with images

            // Перемешиваем элементы в words
            words = words.OrderBy(x => random.Next()).ToArray();

            foreach (string word in words)
            {
                if (word.StartsWith("[") && word.EndsWith("]"))
                {
                    // Удаляем из слова []
                    string wordWithoutBrackets = word.Trim('[', ']');
                    if (wordImagePairs.TryGetValue(wordWithoutBrackets, out ImageSource imageSource))
                    {
                        Image image = new Image();
                        image.Source = imageSource;

                        InlineUIContainer container = new InlineUIContainer(image);
                        inlines.Add(container);

                        // Calculate the total length of the text with images
                        totalLength += word.Length;

                        // Limit the total length of the text with images
                        if (totalLength >= sentence.Length - (iconCount - 1))
                        {
                            break;
                        }
                    }
                    else
                    {
                        inlines.Add(new Run(word + " "));
                        totalLength += word.Length + 1; // Add the length of the word plus the space character
                    }
                }
                else
                {
                    inlines.Add(new Run(word + " "));
                    totalLength += word.Length + 1; // Add the length of the word plus the space character
                }
            }

            return inlines;
        }
    }
}
