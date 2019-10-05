using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace lab_31_tasks
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var t = new Stopwatch();
            var t2 = new Stopwatch();

            // anonymous (lambda) delegate
            var task01 = new Task(() => {
                Console.WriteLine("Running task01");
            });
            task01.Start();

            // delegate is a placeholder for one or more methods
            // simplest delegate is called action
            // ACTION   void DoThis(){}   // no parameters in, void output
            var taskOld = new Task(DoThis);   // named delegate here 
            taskOld.Start();


            var task02 = Task.Run(() => {
                Console.WriteLine("Running Task02");
            });
            Console.ReadLine();

            var taskArray = new Task[10];
            taskArray[0] = Task.Run(() => { Console.WriteLine("Task Array00"); });
            taskArray[1] = Task.Run(() => { Console.WriteLine("Task Array1"); });
            taskArray[2] = Task.Run(() => { Console.WriteLine("Task Array2"); });

            var counter = 3;
            for (int i = 3; i < 10; i++)
            {
                taskArray[counter] = Task.Run(() => { Console.WriteLine($"Task Array {counter}"); });
                System.Threading.Thread.Sleep(10);
                counter++;
            }

            Task.WaitAll(taskArray);
            //Console.ReadLine();

            t.Start();
            //Parallel ForEach
            var mylist = new List<string> { "a", "b", "c" };
            mylist.ForEach((s) =>
            {
                Console.WriteLine($"Item is {s}");
                System.Threading.Thread.Sleep(50);
            });
            t.Stop(); 
            Console.WriteLine(t.ElapsedMilliseconds) ;

            t.Restart();
            // Execute in parralell
            Parallel.ForEach(mylist, (s) => { Console.WriteLine($"Parallel item is {s}"); });
            t.Stop();
            Console.WriteLine(t.ElapsedMilliseconds);

            //Plinq parralel linq
            var output =
                (from item in mylist
                 select item).ToList();
            var outputAsParallel =
                (from item in mylist
                 select item).AsParallel().ToList();

            // Getting Data back from a task
            // var t = Task.Run (   ()=>{}  );
            // var t = Task<T>.Run..... return type of the data T
            // access data t.result
            var taskWithResult = Task<int>.Run(     () =>
            {
                return 100;
            });
            //taskWithResult.Wait();
            Console.WriteLine($"Result of our task is  {taskWithResult}");
            Console.ReadLine();

        }
        static void DoThis() { Console.WriteLine("I am doing something"); }
    }
}