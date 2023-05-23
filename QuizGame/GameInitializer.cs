using System.Windows.Media.Imaging;
using System.Windows.Media;
using System;

namespace QuizGame
{
    public class GameInitializer
    {
        public MainWindow mainWindow;

        private readonly int iconCount = 3; // The selected icon count, default value 1

        // TODO: Спросить у И.Е. почему визуалка советует readonly и private
        private readonly QuizData quizData = new QuizData();

        public GameInitializer(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void Initialize()
        {
            WordImageMap wordImageMap = InitializeWordImageMap();
            Model model = InitializeModel();

            View view = new View(mainWindow);

            // Отобразите первый вопрос
            Controller controller = new Controller(model, wordImageMap, view, iconCount);

            mainWindow.controller = controller;
            mainWindow.view = view;

            controller.DisplayCurrentQuestion();
        }

        private ImageSource GetImageSource(string imagePath)
        {
            BitmapImage imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.UriSource = new Uri(imagePath, UriKind.Relative);
            imageSource.EndInit();

            return imageSource;
        }

        private WordImageMap InitializeWordImageMap()
        {
            WordImageMap wordImageMap = new WordImageMap();

            string[] sentencesImages = quizData.SentencesImages;

            foreach (string imageName in sentencesImages)
            {
                // Сплитим по точке и берём первый элемент (для связки с картинкой)
                string word = imageName.Split('.')[0];
                wordImageMap.AddWordImagePair(word, GetImageSource(imageName));
            }

            return wordImageMap;
        }

        private Model InitializeModel()
        {
            Model model = new Model();

            for (int i = 0; i < quizData.Questions.Length; i++)
            {
                model.AddQuestion(quizData.Questions[i], quizData.Answers[i]);
            }

            return model;
        }
    }
}
