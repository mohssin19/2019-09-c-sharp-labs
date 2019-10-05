using System;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace lab_38_raw_sql
{
    class Program
    {
        static List<Customer> listCustomers = new List<Customer>();
        static string connectionstring = @"Data Source=(localdb)\mssqllocaldb; Initial Catalog=Northwind;";
        static void Main(string[] args)
        {
            //InsertCustomer();
            GetCustomers();
            UpdateCustomer();
            
        }
        static void GetCustomers()
        {
            // raw sql 
            string connectionstring = @"Data Source=(localdb)\mssqllocaldb; Initial Catalog=Northwind;";

            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                Console.WriteLine(connection.State);

                string sqlquery01 = "select * from customers";
                using (var sql = new SqlCommand(sqlquery01, connection))
                {
                    var reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        var CustomerID = reader["CustomerID"].ToString();
                        var ContactName = reader["ContactName"].ToString();
                        var CompanyName = reader["CompanyName"].ToString();
                        var City = reader["City"].ToString();
                        var Country = reader["Country"].ToString();
                        var customer = new Customer(CustomerID, ContactName, CompanyName, City, Country);

                        listCustomers.Add(customer);
                    }
                    listCustomers.ForEach(c => Console.WriteLine($"{c.ContactName, -10},{c.Country,-10}, {c.CustomerID}"));

                    Console.WriteLine($"\nThere are {listCustomers.Count}");
                }

            }
        }

        static void InsertCustomer()
        {
            string connectionstring = @"Data Source=(localdb)\mssqllocaldb; Initial Catalog=Northwind;";



            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var FixedCustomer = new Customer(RandomID(), "Mohssin", "Sparta", "London", "Uk");
                string sqlstring = $"INSERT INTO CUSTOMERS (CustomerID, ContactName, CompanyName, City, Country)" +
                    $"VALUES ('{FixedCustomer.CustomerID}',' {FixedCustomer.ContactName}',' {FixedCustomer.CompanyName}'" +
                    $",'{FixedCustomer.City}','{FixedCustomer.Country}')";

                using (var sqlcommand = new SqlCommand(sqlstring, connection))
                {
                    var affected = sqlcommand.ExecuteReader();
                    Console.WriteLine($"{affected} rows affected");
                }

                Console.WriteLine($"\n\n{"Customer"}");
            }

           
        }

        static void UpdateCustomer()
        {
            string connectionstring = @"Data Source=(localdb)\mssqllocaldb; Initial Catalog=Northwind;";
       
            

            using (var sqlconnection = new SqlConnection(connectionstring))
            {
                sqlconnection.Open();
                var customerIdToUpdate = "ALFKI";
                var sqlUpdate = $"UPDATE Customers SET City='Paris' WHERE CustomerID = '{customerIdToUpdate}'";
                using (var sqlcommand = new SqlCommand(sqlUpdate, sqlconnection))
                {
                    int affected = sqlcommand.ExecuteNonQuery();
                    Console.WriteLine($"Number of records updated : {affected} ");
                }
            }
            
            

        }

        static string RandomID()
        {
            string letters = "ABCEDEFGHIJKLMNOPQRSTUVWXYZ";
            int length = letters.Length;
            string ID = "";

            for (int i = 0; i < 5; i++)
            {
                Random r = new Random();
                ID += letters[r.Next(0, letters.Length - 1)];
            }
            return ID;


        }
    }
       


    public class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }


        public Customer(string CustomerId, string contactName, string companyName, string city, string country)
        {
            CustomerID = CustomerId;
            ContactName = contactName;
            CompanyName = companyName;
            City = city;
            Country = country;

        }
    }
}
