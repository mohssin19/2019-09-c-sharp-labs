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
        // Local DB data in a list
        static List<Customer> customers;
        static List<Order> orders;
        static List<Order_Detail> orderDetails;

        static Customer selectedCustomer = null;
        static Order selectedOrder = null;

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
            editName.IsEnabled = false;

            using (var db = new NorthwindEntities())
            {
                customers = db.Customers.ToList();
                orders = db.Orders.ToList();
                orderDetails = db.Order_Details.ToList();
                ListBoxCustomers.ItemsSource = customers;
                ListBoxOrders.ItemsSource = orders;
                ListBoxOrderDetails.ItemsSource = orderDetails;
                listGrid1.ItemsSource = customers;


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
              ListBoxCustomers.ItemsSource = customers.Where(c => c.ContactName.ToLower().Contains(CustomerSearch.Text) && (c.City.ToLower().Contains(CitySearch.Text))).ToList();

        }

        private void ListBoxCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void ListBoxCustomers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            StackPanel.Visibility = Visibility.Collapsed;
            StackPanel2.Visibility = Visibility.Visible;
            StackPanel3.Visibility = Visibility.Collapsed;

            selectedCustomer = (Customer)ListBoxCustomers.SelectedItem;
            ListBoxOrders.ItemsSource = orders.Where
                //(o => o.OrderID.ToString().Contains(OrderSearch.Text)).ToList();
                (o => o.CustomerID == selectedCustomer.CustomerID).ToList();

            // customer ID orderID from populated orders list
        }

        private void OrderSearch_KeyUp(object sender, KeyEventArgs e)
        {
            ListBoxOrders.ItemsSource = orders.Where(o => o.OrderID.ToString().Contains(OrderSearch.Text)).ToList();
        }


     
        private void ListBoxOrders_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            // making panel 3 show
            StackPanel.Visibility = Visibility.Collapsed;
            StackPanel2.Visibility = Visibility.Collapsed;
            StackPanel3.Visibility = Visibility.Visible;

            // Outputting order details info
            selectedOrder = (Order)ListBoxOrders.SelectedItem;
            ListBoxOrderDetails.ItemsSource = orderDetails.Where
                (od => od.OrderID == selectedOrder.OrderID).ToList();

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            editName.IsEnabled = true;
            
        }

        private void ListGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listGrid1.SelectedItem != null)
            {
                selectedCustomer = (Customer)listGrid1.SelectedItem;
                editName.Text = selectedCustomer.CustomerID.ToString() + " " + selectedCustomer.ContactName.ToString() + " " + selectedCustomer.City.ToString();

            }
        }
    }
}
