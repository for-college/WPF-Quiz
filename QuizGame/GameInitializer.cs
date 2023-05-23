using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace QuizGame
{
    public class GameInitializer
    {
        private MainWindow mainWindow;
        
        QuizData quizData = new QuizData();

        public GameInitializer(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void Initialize()
        {
            WordImageMap wordImageMap = InitializeWordImageMap();
            Model model = InitializeModel();

            View view = new View(mainWindow);
            Controller controller = new Controller(model, wordImageMap, view);

            mainWindow.controller = controller;
            mainWindow.view = view;

            // Отобразите первый вопрос
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
                // Сплитим до по точке и берём первый элемент (для словаря)
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
