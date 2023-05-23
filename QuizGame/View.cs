using System.Windows.Controls;
using System.Windows.Media;

namespace QuizGame
{
    public class View
    {
        private readonly MainWindow mainWindow;

        public View(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public TextBlock QuestionTextBlock => mainWindow.QuestionTextBlock;

        public string GetAnswer()
        {
            return mainWindow.AnswerTextBox.Text;
        }

        public void ClearAnswer()
        {
            mainWindow.AnswerTextBox.Clear();
        }

        public void SetQuestionText(string text)
        {
            mainWindow.Dispatcher.Invoke(() =>
            {
                mainWindow.QuestionTextBlock.Text = text;
            });
        }

        public void SetImageSource(ImageSource source)
        {
            mainWindow.Dispatcher.Invoke(() =>
            {
                mainWindow.Image.Source = source;
            });
        }
    }
}
