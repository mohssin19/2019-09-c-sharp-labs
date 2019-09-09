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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Just_Do_It_12_Rabbit_Explosion;
using System.Data.Entity;
using System.Windows.Threading;


namespace Just_Do_It_12_Rabbit_Explosion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += TimerTicked;

            
            
        }

        public void TimerTicked(object sender, EventArgs e)
        {
            timer.Stop();
            bugsImage.Visibility = Visibility.Hidden;
            
        }
        public void createRabbit()
        {
            Random r = new Random();
            Image BodyImage = new Image
            {
                Width = r.Next(50, 200),
                Height = r.Next(50, 200),
                Name = "myRabbit",
                Source = new BitmapImage(new Uri(@"C:\Users\Mohssin Abihilal\Desktop\bugsBunny.png", UriKind.RelativeOrAbsolute)),
            };

            gridLink.Children.Add(BodyImage);
            Grid.SetColumn(BodyImage, (0));
            Grid.SetRow(BodyImage, (1));
        }
        void AddRabbits()
        {
            var newRabbit = new Rabbit()
            {
                Age = Int32.Parse(txtAge.Text),
                Name = txtName.Text

            };

            using (var db = new RabbitDbEntities())
            {
                db.Rabbits.Add(newRabbit);
                db.SaveChanges();
            }

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
             
                AddRabbits();
                MessageBox.Show("Rabbit Name & Age Added!");
                createRabbit();
                
                
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //using (var db = new RabbitDbEntities())
            //{
            //    db.Rabbits.Load();
            //}

            using (var db = new RabbitDbEntities())
            {
                List<Rabbit> rabbits = db.Rabbits.ToList();



                foreach (Rabbit rb in rabbits)
                {
                    listBox1.Items.Add(rb.RabbitID);
                    listBox2.Items.Add(rb.Name);
                    listBox3.Items.Add(rb.Age);
                    bugsImage.Visibility = Visibility.Visible;
                    timer.Start();

                    //dataGrid1.Items.Add(rb.RabbitID);
                    //dataGrid1.Items.Add(rb.Name);
                    //dataGrid1.Items.Add(rb.Age);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Just_Do_It_12_Rabbit_Explosion.RabbitDbDataSet rabbitDbDataSet = ((Just_Do_It_12_Rabbit_Explosion.RabbitDbDataSet)(this.FindResource("rabbitDbDataSet")));
            // Load data into the table Rabbits. You can modify this code as needed.
            Just_Do_It_12_Rabbit_Explosion.RabbitDbDataSetTableAdapters.RabbitsTableAdapter rabbitDbDataSetRabbitsTableAdapter = new Just_Do_It_12_Rabbit_Explosion.RabbitDbDataSetTableAdapters.RabbitsTableAdapter();
            rabbitDbDataSetRabbitsTableAdapter.Fill(rabbitDbDataSet.Rabbits);
            System.Windows.Data.CollectionViewSource rabbitsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("rabbitsViewSource")));
            rabbitsViewSource.View.MoveCurrentToFirst();
            

        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}
