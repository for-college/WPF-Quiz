using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace QuizGame
{
    public class GameInitializer
    {
        private MainWindow mainWindow;

        public GameInitializer(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void Initialize()
        {
            WordImageMap wordImageMap = InitializeWordImageMap();
            Model model = InitializeModel(wordImageMap);

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

            string[] sentencesImages = { 
                // 1
                "me.png",
                "birch.png",
                "under.png",
                "window.png",
                // 2
                "guys.png",
                "river.png",
                "swimming.png",
                // 3
                "berries.png",
                "mushrooms.png",
                // 4
                "basketball.png",
                "football.png",
                "hockey.png",
                "running.png",
                "volleyball.png",
                // 5
                "rain.png",
                "rainbow.png",
                "stop.png",
                "wait.png",
                // 6
                "fog.png",
                "look.png",
                "us.png",
                // 7
                "apple.png",
                "pears.png",
            };
            foreach (string imageName in sentencesImages)
            {
                // Сплитим до по точке и берём первый элемент (для словаря)
                string word = imageName.Split('.')[0];
                wordImageMap.AddWordImagePair(word, GetImageSource(imageName));
            }

            return wordImageMap;
        }

        private Model InitializeModel(WordImageMap wordImageMap)
        {
            Model model = new Model();

            // Добавление вопросов в модель
            model.AddQuestion("Белая [birch] [under] [me] [window]", "Белая береза под моим окном");
            model.AddQuestion("[guys] [swimming] в [river]", "Мальчики купаются в речке");
            model.AddQuestion("Завтра утром [me] пойду в лес за [mushrooms] и [berries]", "Завтра утром я пойду в лес за грибами и ягодами");
            model.AddQuestion("Гена перечислил известные виды спорта: [football] , [basketball] , [volleyball] , [hockey] , [running]", "Гена перечислил известные виды спорта: футбол, баскетбол, волейбол, хоккей, бег");
            model.AddQuestion("После [rain] дети [wait] [rainbow] , но [rain] не собирался [stop]", "После дождя дети ждали радугу, но дождь не собирался останавливаться");
            model.AddQuestion("[us] [look] овраг лишь тогда, когда рассеялся [fog]", "Мы увидели овраг лишь тогда, когда рассеялся туман");
            model.AddQuestion("После [rain] дети [wait] [rainbow] , но [rain] не собирался [stop]", "После дождя дети ждали радугу, но дождь не собирался останавливаться");

            return model;
        }
    }
}
