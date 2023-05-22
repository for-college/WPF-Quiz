using System.Windows;

namespace QuizGame
{
    public partial class Rules : Window
    {
        private readonly string[] rules;
        private int counter;

        public Rules()
        {
            InitializeComponent();
            ruleButtonBefore.IsEnabled = false;

            rules = new string[]
            {
                "В качестве ответа надо ввести предложение, в котором все изображения заменены на предполагаемые слова",
                "Количество времени зависит от сложности (2-5 минут). По умолчанию - 3",
                "Вы побеждаете, если смогли восстановить не менее половины исходного текста",
                "Вы можете выбрать количество пиктограмм (от 2 до 5). По умолчанию - 3",
                "Удачной игры!"
            };

            counter = 0;
            UpdateRuleText();
        }

        private void NextRule(object sender, RoutedEventArgs e)
        {
            counter++;
            UpdateRuleText();
        }

        private void PrevRule(object sender, RoutedEventArgs e)
        {
            counter--;
            UpdateRuleText();
        }

        private void UpdateRuleText()
        {
            ruleButtonBefore.IsEnabled = counter > 0;
            ruleButtonNext.IsEnabled = counter < rules.Length - 1;
            rulesBlock.Text = $" [{counter + 1}/{rules.Length}] {rules[counter]}";
        }

        private void CloseWindow(object sender, RoutedEventArgs e) => Close();
    }
}
