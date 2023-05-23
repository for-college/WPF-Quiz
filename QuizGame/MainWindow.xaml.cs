using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace QuizGame
{
    public partial class MainWindow : Window
    {
        private Controller controller;
        private View view;

        public MainWindow()
        {
            InitializeComponent();

            InitializeWordImageMap();
            InitializeQuestions();

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

        private void InitializeWordImageMap()
        {
            WordImageMap wordImageMap = new WordImageMap();

            // TODO: Придумать как это вынести куда-то
            // TODO: В каких-то предложениях слишком мало пиктограмм

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

            // Создать контроллер с передачей wordImageMap
            Model model = new Model();
            view = new View(this);
            controller = new Controller(model, wordImageMap, view);
        }

        private void InitializeQuestions()
        {
            // Добавление вопросов
            controller.AddQuestion("Белая [birch] [under] [me] [window]", "Белая береза под моим окном");
            controller.AddQuestion("[guys] [swimming] в [river]", "Мальчики купаются в речке");
            controller.AddQuestion("Завтра утром [me] пойду в лес за [mushrooms] и [berries]", "Завтра утром я пойду в лес за грибами и ягодами");
            controller.AddQuestion("Гена перечислил известные виды спорта: [football] , [basketball] , [volleyball] , [hockey] , [running]", "Гена перечислил известные виды спорта: футбол, баскетбол, волейбол, хоккей, бег");
            controller.AddQuestion("После [rain] дети [wait] [rainbow] , но [rain] не собирался [stop]", "После дождя дети ждали радугу, но дождь не собирался останавливаться");
            controller.AddQuestion("[us] [look] овраг лишь тогда, когда рассеялся [fog]", "Мы увидели овраг лишь тогда, когда рассеялся туман");
            controller.AddQuestion("После [rain] дети [wait] [rainbow] , но [rain] не собирался [stop]", "После дождя дети ждали радугу, но дождь не собирался останавливаться");
        }

        private void SubmitAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            string answer = AnswerTextBox.Text;
            controller.CheckAnswer(answer);
            AnswerTextBox.Text = string.Empty; // Очистить поле ввода ответа
        }

        private void ShowRules(object sender, RoutedEventArgs e)
        {
            Rules rules = new Rules();
            rules.ShowDialog();
        }
    }
}
