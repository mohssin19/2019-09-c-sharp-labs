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

namespace lab_18_rabbit_database_crud
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Rabbit> rabbits;
        static Rabbit rabbit = new Rabbit();

        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        void Initialise()
        {

            // using = auto clean up c# will clear the memory
            using (var db = new RabbitDbEntities())
            {
                rabbits = db.Rabbits.ToList();
            }

            // manual method
            //rabbits.ForEach(rabbit => ListBoxRabbits.Items.Add(rabbit))

            // Binding the listbox to the database
            ListBoxRabbits.ItemsSource = rabbits;

            TextBoxName.IsReadOnly = true;
            AgeBoxName.IsReadOnly = true;

            ButtonEdit.IsEnabled = false;
            ButtonDelete.IsEnabled = false;
        }

        private void ListBoxRabbits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxRabbits.SelectedItem != null)
            {
                // whenever we select an item in the list cast from an object 
                rabbit = (Rabbit)ListBoxRabbits.SelectedItem;
                TextBoxName.Text = rabbit.Name;
                AgeBoxName.Text = rabbit.Age.ToString();
                //enable edit and delete
                ButtonEdit.IsEnabled = true;
                ButtonDelete.IsEnabled = true;

                
            }

        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (ButtonAdd.Content.Equals("Add"))
            {
                ButtonAdd.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D9C216"));
                ButtonAdd.Content ="Save";
                TextBoxName.Text = "";
                AgeBoxName.Text = "";
                TextBoxName.IsReadOnly = false;
                AgeBoxName.IsReadOnly = false;
                ButtonEdit.IsEnabled = false;
                ButtonDelete.IsEnabled = false;
                //ButtonAdd.IsEnabled = false;
            }
            else
            {
                {
                    ButtonAdd.Content = "Add";
                    ButtonAdd.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B3C6ED"));
                    TextBoxName.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D3E9ED"));
                    AgeBoxName.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D3E9ED"));
                    TextBoxName.IsReadOnly = true;
                    AgeBoxName.IsReadOnly = true;
                    // commit changes
                    if ((TextBoxName.Text.Length > 0) && (AgeBoxName.Text.Length > 0))
                    {
                        // get age
                        if (int.TryParse(AgeBoxName.Text, out int age))
                        {
                            var RabbitToAdd = new Rabbit()
                            {
                                Name = TextBoxName.Text,
                                Age = age
                            };
                            // read db and add new rabbit
                            using (var db = new RabbitDbEntities())
                            {
                                db.Rabbits.Add(RabbitToAdd);
                                db.SaveChanges();
                                // update view
                                rabbit = null;

                                rabbits = db.Rabbits.ToList();
                                ListBoxRabbits.ItemsSource = null;
                                ListBoxRabbits.ItemsSource = rabbits;
                            }
                        }
                    }
                    ButtonAdd.IsEnabled = true;
                }
            }
        }
        

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if(ButtonEdit.Content.Equals("Edit"))
            {
                ButtonEdit.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D9C216"));
                ButtonEdit.Content = "Save";
                TextBoxName.IsReadOnly = false;
                AgeBoxName.IsReadOnly = false;
            }
            else
            {
                ButtonEdit.Content = "Edit";
                if((TextBoxName.Text.Length>0)&&(AgeBoxName.Text.Length>0))
                {
                    if (rabbit != null)
                    {
                        rabbit.Name = TextBoxName.Text;
                       // rabbit.Age = AgeBoxName.Text.ToString();
                        if(int.TryParse(AgeBoxName.Text, out int age))
                        {
                            rabbit.Age = age;
                        }

                        using (var db = new RabbitDbEntities())
                        {
                            // read rabbit from database by ID,
                            var rabbitToUpdate = db.Rabbits.Find(rabbit.RabbitID);
                            //update rabbit
                            rabbitToUpdate.Name = rabbit.Name;
                            rabbitToUpdate.Age = rabbit.Age;
                            //save rabbit to db
                            db.SaveChanges();
                            rabbit = null;
                            // clear listbox
                            ListBoxRabbits.ItemsSource = null; // remove binding
                            ListBoxRabbits.Items.Clear(); // clear it out
                            // repopulate listbox 
                            rabbits = db.Rabbits.ToList(); // get rabbits
                            ListBoxRabbits.ItemsSource = rabbits; // bind to list again

                        }




                    }
                }
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonDelete.Content.Equals("Delete"))
            {
                ButtonDelete.Content = "Confirm Delete";
            }
            else
            {
                //delete record
                //find record in database which matches selected rabbit
                if (rabbit != null)
                {
                    using (var db = new RabbitDbEntities())
                    {
                        var rabbitToDelete = db.Rabbits.Find(rabbit.RabbitID);
                        db.Rabbits.Remove(rabbitToDelete);
                        db.SaveChanges();

                        rabbits = db.Rabbits.ToList();

                        ListBoxRabbits.ItemsSource = rabbits;
                    }
                }


                ButtonDelete.Content = "Delete";
            }
        }
    }
}
