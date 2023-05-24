using System.Windows.Controls;
using System.Windows.Media;

namespace QuizGame
{
    public class View
    {
        public MainWindow MainWindow { get; }

        public View(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
        }

        public TextBlock QuestionTextBlock => MainWindow.QuestionTextBlock;


        public string GetAnswer()
        {
            return MainWindow.AnswerTextBox.Text;
        }

        public void ClearAnswer()
        {
            MainWindow.AnswerTextBox.Clear();
        }

        public void SetQuestionText(string text)
        {
            MainWindow.Dispatcher.Invoke(() =>
            {
                MainWindow.QuestionTextBlock.Text = text;
            });
        }

        public void SetImageSource(ImageSource source)
        {
            MainWindow.Dispatcher.Invoke(() =>
            {
                MainWindow.Image.Source = source;
            });
        }
    }
}
