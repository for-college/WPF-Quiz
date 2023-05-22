using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace QuizGame
{
    public partial class MainWindow : Window
    {
        private Controller controller;

        public MainWindow()
        {
            InitializeComponent();

            InitializeWordImageMap();
            InitializeQuestions();

            // Отобразите первый вопрос
            controller.DisplayCurrentQuestion();
        }

        private void InitializeWordImageMap()
        {
            WordImageMap wordImageMap = new WordImageMap();
            string imagePath = "me.png"; // Относительный путь к картинке

            BitmapImage imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.UriSource = new Uri(imagePath, UriKind.Relative);
            imageSource.EndInit();

            wordImageMap.AddWordImagePair("apple", imageSource);
            wordImageMap.AddWordImagePair("banana", imageSource);
            wordImageMap.AddWordImagePair("orange", imageSource);

            // Создать контроллер с передачей wordImageMap
            Model model = new Model();
            controller = new Controller(model, wordImageMap, this);
        }

        private void InitializeQuestions()
        {
            // Добавьте несколько вопросов
            controller.AddQuestion("I have a [apple] and an [orange]", "I have a apple and an orange");
            controller.AddQuestion("She likes [banana]", "She likes bananas");
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
