using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuizGame
{
    /// <summary>
    /// Логика взаимодействия для Rules.xaml
    /// </summary>
    public partial class Rules : Window
    {
        public Rules()
        {
            InitializeComponent();
            ruleButtonBefore.IsEnabled = false;
        }
        int counter;

        readonly string[] rules = 
            {
                "В качестве ответа надо ввести предложение, в котором все изображения заменены на предполагаемые слова",
                "Количество времени зависит от сложности (2-5 минут). По умолчанию - 3",
                "Вы побеждаете, если смогли восстановить не менее половины исходного текста",
                "Вы можете выбрать количество пиктограмм (от 2 до 5). По умолчанию - 3",
                "Удачной игры!"
            };
        private void NextRule(object sender, RoutedEventArgs e)
        {
            if (counter == 1) ruleButtonBefore.IsEnabled = true;
            if (counter + 1 == rules.Length) ruleButtonNext.IsEnabled = false;
            else ruleButtonNext.IsEnabled = true;
            rulesBlock.Text = $" [{counter + 1}/" + rules.Length + "] " + rules[counter];
            counter++;
        }
        private void PrevRule(object sender, RoutedEventArgs e)
        {
            counter--;
            if (counter - 1 <= 0)
            {
                ruleButtonBefore.IsEnabled = false;
                ruleButtonNext.IsEnabled = true;
            }
            else
            {
                ruleButtonBefore.IsEnabled = true;
                ruleButtonNext.IsEnabled = true;
            }
            rulesBlock.Text = $" [{counter}/" + rules.Length + "] " + rules[counter - 1];
        }
        public void CloseWindow(object sender, RoutedEventArgs e) => Close();
    }
}
