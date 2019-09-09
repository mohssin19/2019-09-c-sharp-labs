using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_17_rabbit_database_explosion
{
    class Program
    {
        static List<Rabbit> rabbits;
        static void Main(string[] args)
        {

             void printRabbits()
            {
                rabbits.ForEach(rabbit => Console.WriteLine($"{rabbit.RabbitID,-5}" +
                $"{rabbit.Name,-12}{rabbit.Age}"));
            }
             
            using (var db = new RabbitDbEntities())
            {
                rabbits = db.Rabbits.ToList();
            }

            //print rabbits
            printRabbits();


            //foreach(var rabbit in rabbits)
            //{
            //    Console.WriteLine($"{rabbit.RabbitID,-5}{rabbit.Name,-12}{rabbit.Age}");
            //}

            //new rabbt : wpf Textbox01.tect ==> use for Age, Name (2boxes)
            // button : run this code


            var newRabbit = new Rabbit()
            {
                Age = 0,
                Name = $"Rabbit{rabbits.Count+1}"

            };

            using (var db = new RabbitDbEntities())
            {
                db.Rabbits.Add(newRabbit);
                db.SaveChanges();
            }
            //pause to ensure database has finished writing 
            System.Threading.Thread.Sleep(200);
            Console.ReadLine();
            //read db from scratch
            using (var db = new RabbitDbEntities())
            {
                printRabbits();
            }
            Console.ReadKey();

        }
    }
}
