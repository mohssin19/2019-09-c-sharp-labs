using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace project_1000_console
{
    class Program
    {
        static List<Rabbit> rabbits;
        static void Main(string[] args)
        {
            var timer = new Stopwatch();

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
            
            //timer.Stop();
            //Console.WriteLine("1 read took: " + timer.ElapsedMilliseconds);
            // one read
            timer.Start();

            using (var db = new RabbitDbEntities())
            {
                rabbits = db.Rabbits.ToList();
            }
            timer.Stop();

            Console.WriteLine("1 Read took: " + timer.ElapsedMilliseconds + "Milliseconds");


            timer.Restart();
            // 1000 reads
            for (int i = 0; i < numberOfRabbitsToCreate; i++)
            {
                using (var db = new RabbitDbEntities())
                {
                    Rabbit newRabbit = db.Rabbits.Find(i + 1);
                    //Rabbit newRabbit = db.Rabbits.ToList()[i];
                    rabbits.Add(newRabbit);
                }
            }
            timer.Stop();
            Console.WriteLine("1000 reads took: " + timer.ElapsedMilliseconds);
           

            // REPORT TIMES TO CONSOLE
            // REPORT TIMES TO CSV
            File.WriteAllText("Rabbits.csv", "ID,Name,Age");
            File.AppendAllText("Rabbits.csv", "\n1,Billy,12");
            File.AppendAllText("Rabbits.csv", "\n2,Fluffy,13");
            Process.Start("Rabbits.csv");
            Console.ReadKey();
            // REPORT TIMES TO WORD
            // SPRINT 2: move everything to WPF
        }
    }
}
