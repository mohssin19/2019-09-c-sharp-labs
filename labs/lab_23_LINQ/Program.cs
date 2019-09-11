using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_23_LINQ
{
    class Program
    {
        static List<Customer> customers;
        static void Main(string[] args)
        {
            using (var db= new NorthwindEntities())
            {
                customers = db.Customers.ToList();
                

                //cannot print this#
                //LINQ produces output of IQueryable
                // this is an abstract type so we cast it to a list
                var output1 =
                    (from customer in db.Customers
                    select customer).ToList();
                Console.WriteLine("\n\nTrivial Linq query");
                //output1.ForEach(c => { Console.WriteLine($"{c.CustomerID}"); });
                PrintCustomers(output1);
                Console.WriteLine("---------------------------------------------------------------------");

                Console.WriteLine("");
                var LINQwhere =
                    (from customer in db.Customers
                     where customer.City == "London" || customer.City == "Berlin"
                     select customer);
                //LINQwhere.ToList().ForEach(c => Console.WriteLine($"{c.CustomerID,-10}{c.City}"));
                PrintCustomers(LINQwhere.ToList());
                Console.WriteLine("---------------------------------------------------------------------");

                Console.WriteLine("\n\nOrder By Customer Name \n");
                var LINQOrderBy =
                    (from customer in db.Customers
                     where customer.City == "London"
                     orderby customer.ContactName descending
                     select customer).ToList();
                PrintCustomers(LINQOrderBy);
                Console.WriteLine("---------------------------------------------------------------------");

                Console.WriteLine();
                //lambda has order by, then by
                var LINQOrderByThenBy =
                    db.Customers.Where(c => c.City == "London" || c.City == "Berlin" ||
                    c.City== "Madrid")
                    .OrderBy(c => c.City)
                    .ThenBy(c => c.ContactName)
                    .ToList();
                PrintCustomers(LINQOrderByThenBy);
                Console.WriteLine("---------------------------------------------------------------------");

                var customObject =
                    from c in db.Customers
                    where c.City =="Berlin"
                    join order in db.Orders
                        on c.CustomerID equals order.CustomerID
                    select new
                    {
                        Name = c.ContactName,
                        OrderID = order.OrderID,
                        OrderDate = order.OrderDate,
                        ShipCity = order.ShipCity

                    };
                // manual print
                customObject.ToList().ForEach(item => Console.WriteLine($"" +
                    $"{item.Name,-20}{item.OrderID,-10}{item.OrderDate,-12}{item.ShipCity}"));
                Console.WriteLine("---------------------------------------------------------------------");
                

                // slick version: read only
                //db.Customers.Where(c=>c.City =="Berlin" ).ToList().ForEach(c =>
                db.Orders.Where(o=>o.Customer.City=="Berlin").ToList().ForEach(o =>
                {
                    // print name and city
                    Console.WriteLine($"{ o.Customer.ContactName,-20}{o.Customer.City}{o.OrderID}{o.OrderDate:dd/mm/yyyy}");


                });

                Console.WriteLine("\n\n\nJoining 4 tables and then some");
                db.Order_Details.Where(od => od.Order.Customer.City == "Berlin").ToList()
                    .ForEach(od =>
                    {
                        Console.WriteLine($"{od.Order.Customer.ContactName, -20} |" +
                            $"{od.Order.Customer.City,-10} |" +
                            $"{od.OrderID,-15} |" +
                            $"{od.ProductID,-10} |" +
                            $"{od.Product.ProductName,-35} |" +
                            $"{od.Order.OrderDate:dd/mm/yyy} |");

                    });


                Console.ReadKey();
            }
          
        }
        static void PrintCustomers(List<Customer> customers)
        {
            customers.ForEach(c => Console.WriteLine($" | {c.CustomerID,-10} | {c.ContactName,-20} |" +
                $"{c.Address,-30} | {c.City,-15} | {c.Country}"));
        }
    }
}
