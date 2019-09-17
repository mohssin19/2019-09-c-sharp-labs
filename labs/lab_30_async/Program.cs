using System;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Collections.Generic;

namespace lab_30_async
{
    class Program
    {
        static List<string> lines = new List<string>();
        static Stopwatch s = new Stopwatch();
        
        static void Main(string[] args)
        {
            
            

            //File.Delete("data.txt");
            //for (int i = 0; i <100000 ; i++)
            //{
            //    File.AppendAllText("data.txt",$"\nAdding Line{i} at {DateTime.Now}");
            //}


            //DoThisLongThing();
            DoThisLongThingAsync();

            s.Stop();
            Console.WriteLine(s.Elapsed);
            Console.ReadLine();
        }

        static void DoThisLongThing()
        {
            Thread.Sleep(3000);
        }

        async static void DoThisLongThingAsync()
        {
            s.Start();
            //// create dummy data
            //for (int i = 0; i <10000 ; i++)
            //{
            //    File.AppendAllText("data.txt", $"Adding Line{i} at {DateTime.Now}");
            //}

            //stream in lines using streamreader (when we dont know exactly what were pulling in)
            using (var reader = new StreamReader("data.txt"))
            {
                while (true)
                {
                    var line = await reader.ReadLineAsync();
                    if(line == null)
                    {
                        break;
                    }
                    lines.Add(line);
                }
                s.Stop();
            }
            Console.WriteLine($"Finished Reading {lines.Count} lines");
        }
    }
}
