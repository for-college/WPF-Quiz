using System.Windows.Controls;
using System.Windows.Media;

namespace QuizGame
{
    public class View
    {
        public MainWindow MainWindow { get; } // Главное окно представления

        public View(MainWindow mainWindow)
        {
            MainWindow = mainWindow; // Установка главного окна представления
        }

        public TextBlock QuestionTextBlock => MainWindow.QuestionTextBlock; // Текстовый блок для отображения вопроса

        public string GetAnswer()
        {
            return MainWindow.AnswerTextBox.Text; // Получение ответа из текстового поля
        }

        public void ClearAnswer()
        {
            MainWindow.AnswerTextBox.Clear(); // Очистка текстового поля с ответом
        }

        public void SetQuestionText(string text)
        {
            MainWindow.Dispatcher.Invoke(() =>
            {
                MainWindow.QuestionTextBlock.Text = text; // Установка текста вопроса в текстовый блок
            });
        }

        public void SetImageSource(ImageSource source)
        {
            MainWindow.Dispatcher.Invoke(() =>
            {
                MainWindow.Image.Source = source; // Установка источника изображения
            });
        }
    }
}
