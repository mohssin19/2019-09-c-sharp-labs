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

namespace lab_24_Customers_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Customer> customers;
        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        void Initialise()
        {
            StackPanel.Visibility = Visibility.Visible;
            StackPanel2.Visibility = Visibility.Hidden;
            StackPanel3.Visibility = Visibility.Hidden;

            using (var db = new NorthwindEntities())
            {
                customers = db.Customers.ToList();
                ListBoxCustomers.ItemsSource = customers;
                

            }
        }
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (StackPanel.Visibility == Visibility.Visible)
            {
                StackPanel.Visibility = Visibility.Collapsed;
                StackPanel2.Visibility = Visibility.Collapsed;
                StackPanel3.Visibility = Visibility.Visible;
            }
            else if (StackPanel2.Visibility == Visibility.Visible)
            {
                StackPanel.Visibility = Visibility.Visible;
                StackPanel2.Visibility = Visibility.Collapsed;
                StackPanel3.Visibility = Visibility.Collapsed;
            }
            else if (StackPanel3.Visibility == Visibility.Visible)
            {
                StackPanel.Visibility = Visibility.Collapsed;
                StackPanel2.Visibility = Visibility.Visible;
                StackPanel3.Visibility = Visibility.Collapsed;
            }
        }

        private void ButtonForward_Click(object sender, RoutedEventArgs e)
        {
            if (StackPanel.Visibility == Visibility.Visible)
            {
                StackPanel.Visibility = Visibility.Collapsed;
                StackPanel2.Visibility = Visibility.Visible;
                StackPanel3.Visibility = Visibility.Collapsed;
            }
            else if (StackPanel2.Visibility == Visibility.Visible)
            {
                StackPanel.Visibility = Visibility.Collapsed;
                StackPanel2.Visibility = Visibility.Collapsed;
                StackPanel3.Visibility = Visibility.Visible;
            }
            else if (StackPanel3.Visibility == Visibility.Visible)
            {
                StackPanel.Visibility = Visibility.Visible;
                StackPanel2.Visibility = Visibility.Collapsed;
                StackPanel3.Visibility = Visibility.Collapsed;
            }
        }

        private void CustomerSearch_KeyUp(object sender, KeyEventArgs e)
        {
              ListBoxCustomers.ItemsSource = customers.Where(c => c.ContactName.Contains(CustomerSearch.Text) && (c.City.Contains(CitySearch.Text))).ToList();

        }
    }
}
