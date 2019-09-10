using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_22_Northwind
{
    class Program
    {
        static List<Product> products;
        static List<Category> categories;
        static void Main(string[] args)
        {
            using (var db = new NorthwindEntities()){
                products = db.Products.ToList();
                categories = db.Categories.ToList();
            }
            products.ForEach(p => Console.WriteLine($"{p.CategoryID,-10}{p.QuantityPerUnit,-10} "));
            products.ForEach(p => Console.WriteLine($"{p.ProductID,-10}{p.ProductName,-10} "));
            Console.ReadLine();
        }
    }
}
