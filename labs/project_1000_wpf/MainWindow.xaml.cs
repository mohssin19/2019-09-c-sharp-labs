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

namespace project_1000_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Rabbit> rabbits;
        static Rabbit rabbit = new Rabbit();

        static Rabbit selectedRabbit = null;
        //static Rabbit rabbit = new Rabbit();

        public MainWindow()
        {
            InitializeComponent();
            initialise();
            
           
            Save.IsEnabled = false;

            using (var db = new RabbitDbEntities())
            {
                rabbits = db.Rabbits.ToList();
            }
        }

        public void initialise()
        {
            using (var db = new RabbitDbEntities())
            {
                rabbits = db.Rabbits.ToList();
                listGrid1.ItemsSource = rabbits;
            }
        }

        public void populate1000()
        {
            int numberOfRabbitsToCreate = 1000;


            for (int i = 0; i < numberOfRabbitsToCreate; i++)
            {
                using (var db = new RabbitDbEntities())
                {
                    var newRabbit = new Rabbit();
                    db.Rabbits.Add(newRabbit);
                    db.SaveChanges();
                }
            }
        }



        private void ListGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listGrid1.SelectedItem != null)
            {


                selectedRabbit = (Rabbit)listGrid1.SelectedItem;
                Name.Text = selectedRabbit.RabbitName.ToString();
                Age.Text = selectedRabbit.Age.ToString();
                Category.Text = selectedRabbit.CategoryId.ToString();

            }
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if ((Save.Content.Equals("Save")) && (selectedRabbit != null))
            {
                using (var db = new RabbitDbEntities())
                {
                    var rabbitToUpdate = db.Rabbits.Find(selectedRabbit.RabbitID);
                    Save.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D9C216"));
                    Save.Content = "Edit Mode";
                    selectedRabbit = (Rabbit)listGrid1.SelectedItem;
                    rabbitToUpdate.RabbitName = Name.Text;
                    db.SaveChanges();
                    rabbit = null;
                    // clear listbox
                    listGrid1.ItemsSource = null; // remove binding
                    listGrid1.Items.Clear(); // clear it out
                    rabbits = db.Rabbits.ToList();
                    listGrid1.ItemsSource = rabbits;

                }

            }
            else
            {

            }
        }

        private void Label_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
        private void Category_DataContextChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RdoButton_Checked(object sender, RoutedEventArgs e)
        {
            Save.IsEnabled = true;
        }
    }
}
