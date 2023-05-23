using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace QuizGame
{
    public partial class MainWindow : Window
    {
        public Controller controller;
        public View view;

        public MainWindow()
        {
            InitializeComponent();

            GameInitializer gameInitializer = new GameInitializer(this);
            gameInitializer.Initialize();
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
