using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace lab_16_wpf_rabbit_explosion
{

    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }
        void Initialise()
        {

            Button01.Content = "Click here";
            timer.Interval = TimeSpan.FromMilliseconds(200);
            timer.Tick += changeColor;


        }

        private void changeColor(object sender, EventArgs e)
        {
            Random rnd = new Random();
            var x = rnd.Next(255);
            var y = rnd.Next(255);
            var z = rnd.Next(255);

            // random colour generator
            Label01.Background = new SolidColorBrush(Color.FromRgb((byte)x, (byte)y, (byte)z));


        }

        static int counter = 0;
        private void Button01_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            counter++;
            Button01.Content = $"{counter} times";

            Random rnd = new Random();
            var x = rnd.Next(255);
            var y = rnd.Next(255);
            var z = rnd.Next(255);




            byte[] imageInfo = File.ReadAllBytes("Transparent-White-Bunny-Rabbit-PNG.png");

            BitmapImage image;

            using (MemoryStream imageStream = new MemoryStream(imageInfo))
            {
                image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = imageStream;
                image.EndInit();
            }

            // random colour generator
            Label01.Background = new SolidColorBrush(Color.FromRgb((byte)x, (byte)y, (byte)z));

           if(rabbitImage.Visibility == Visibility.Visible )
            {
                rabbitImage.Visibility = Visibility.Hidden;
            }
            else
            {
                rabbitImage.Visibility = Visibility.Visible;
            }

            


        }
    }
    
}
