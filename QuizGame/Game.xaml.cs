using QuizGame.ControllerNamespace;
using QuizGame.ModelNamespace;
using QuizGame.ViewNamespace;
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
    /// Логика взаимодействия для Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        private Controller controller; // The Controller object

        public Game()
        {
            InitializeComponent();

            // Create an array of words
            string[] words = new string[] { "The", "cat", "is", "on", "the", "mat" };

            // Create an array of images
            Image[] images = new Image[3];
            images[0] = new Image() { Source = new BitmapImage(new Uri("cat.png", UriKind.Relative)) };
            images[1] = new Image() { Source = new BitmapImage(new Uri("dog.png", UriKind.Relative)) };
            images[2] = new Image() { Source = new BitmapImage(new Uri("bird.png", UriKind.Relative)) };

            // Create instances of the Model, View, and Controller classes
            Model model = new Model(words, images);
            View view = new View(textBlock);
            controller = new Controller(model, view);
        }

        public void AddImageToText(int index, string imagePath)
        {
            // Call the AddImageToText method on the Controller object
            controller.AddImageToText(index, imagePath);
        }
    }
}
