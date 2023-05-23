using System.Windows;
using System.Windows.Controls;

namespace QuizGame
{
    public partial class MainWindow : Window
    {
        public Controller controller;
        public View view;

        public int iconCount = 3;

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

        private void DifficultyCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.IsChecked == true)
            {
                // Update the iconCount based on the selected CheckBox
                switch (checkBox.Name)
                {
                    case "ThreeIconsCheckBox":
                        iconCount = 3;
                        break;
                    case "FourIconsCheckBox":
                        iconCount = 4;
                        break;
                    case "FiveIconsCheckBox":
                        iconCount = 5;
                        break;
                }

                // Update the iconCount in the controller
                controller.UpdateIconCount(iconCount);
            }
        }
    }
}
