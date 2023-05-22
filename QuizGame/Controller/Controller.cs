using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizGame.ViewNamespace;
using QuizGame.ModelNamespace;
using System.Windows.Controls;
using System.Drawing;
using Image = System.Windows.Controls.Image;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace QuizGame.ControllerNamespace
{
    public class Controller
    {
        private Model model;
        private View view;

        public Controller(Model model, View view)
        {
            this.model = model;
            this.view = view;
        }

        public void UpdateDisplay()
        {
            string[] words = model.GetWords();
            Image[] images = model.GetImages();
            int[] indexes = model.GetRandomIndexes();

            view.DisplayText(words, indexes, images);
        }

        public void AddImageToText(int index, string imagePath)
        {
            // Create a Bitmap instance for the image
            Bitmap bitmap = new Bitmap(imagePath);

            // Convert the Bitmap to a BitmapImage
            BitmapImage bitmapImage = new BitmapImage();
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
            }

            // Create an Image control and set its Source property to the BitmapImage
            Image imageControl = new Image();
            imageControl.Source = bitmapImage;

            // Add the Image control to the model's image array
            model.AddImage(imageControl);

            // Add the image index to the model's word array
            model.AddWord("img" + index.ToString());

            // Update the display
            UpdateDisplay();
        }
    }
}
