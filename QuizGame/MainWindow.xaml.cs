using System.Windows;
using System.Windows.Controls;

namespace QuizGame
{
    public partial class MainWindow : Window
    {
        public Controller controller; // Контроллер игры
        public View view; // Представление игры

        public int iconCount = 3; // Количество иконок по умолчанию

        public MainWindow()
        {
            InitializeComponent();

            GameInitializer gameInitializer = new GameInitializer(this); // Инициализация игры
            gameInitializer.Initialize();
        }

        private void SubmitAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            string answer = AnswerTextBox.Text;
            controller.CheckAnswer(answer); // Проверка ответа
            AnswerTextBox.Text = string.Empty; // Очистить поле ввода ответа
        }

        private void ShowRules(object sender, RoutedEventArgs e)
        {
            Rules rules = new Rules(); // Создание окна с правилами игры
            rules.ShowDialog();
        }

        public void OpenEndGameWindow()
        {
            controller.OpenEndGameWindow();
        }

        private void DifficultyCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.IsChecked == true)
            {
                // Обновление значения iconCount в зависимости от выбранного CheckBox
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

                // Обновление значения iconCount в контроллере
                controller.UpdateIconCount(iconCount);
            }
        }
    }
}