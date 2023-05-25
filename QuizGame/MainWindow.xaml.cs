using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

            AnswerTextBox.PreviewTextInput += AnswerTextBox_PreviewTextInput;
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

        private void DifficultyRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton && radioButton.IsChecked == true)
            {
                // Обновление значения iconCount в зависимости от выбранной радиокнопки
                switch (radioButton.Name)
                {
                    case "ThreeIconsRadioButton":
                        iconCount = 3;
                        break;
                    case "FourIconsRadioButton":
                        iconCount = 4;
                        break;
                    case "FiveIconsRadioButton":
                        iconCount = 5;
                        break;
                }

                // Обновление значения iconCount в контроллере
                controller?.UpdateIconCount(iconCount);
            }
        }

        private void AnswerTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string allowedCharsPattern = "^[а-яА-Я,]*$";
            Regex regex = new Regex(allowedCharsPattern);
            if (!regex.IsMatch(e.Text))
            {
                e.Handled = true; // Запретить ввод символа
            }

            // Проверка на подряд идущие заглавные буквы
            if (Regex.IsMatch(AnswerTextBox.Text + e.Text, "[A-Z]{2,}"))
            {
                e.Handled = true; // Запретить ввод символа
            }
        }
    }
}
