using System;
using System.IO;

namespace lab_13_files
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("==Just a single line of text==\n\n");
            if (File.Exists("myFile.txt"))
            { 
                var string1 = File.ReadAllLines("myFile.txt");
                Console.WriteLine(string1);
            }

            //rewriting files 
            File.WriteAllText("output.txt", "some data");
            // \n creates new line in a string 
            Console.WriteLine("\n==save multiple lines==\n\n");

            File.WriteAllText("multiplelines.txt", "some\ndata\nnot\ndifferent");
            Console.WriteLine(File.ReadAllText("multiplelines.txt"));

            File.WriteAllText("multiplelines.txt", "some" + Environment.NewLine + "text");

            Console.WriteLine("== saving some arrays to multiple lines");

            string[] myArray = new string[] { "some", "data", "here", "mplines" };
            File.WriteAllLines("multiLineFile.txt", myArray);
            //read it back
            var outputArray = File.ReadAllLines("multiLineFile.txt");
            Array.ForEach(outputArray,item => Console.WriteLine(item));

            Console.WriteLine("\n== Logging ==\n");

            var d = DateTime.Now;
            Console.WriteLine(d);
            for (int i = 0; i < 10; i++)
            {
                File.AppendAllText("myLogFile.log", $"Event happened at time{DateTime.Now}");
                System.Threading.Thread.Sleep(300);
            }
            Console.WriteLine(File.ReadAllText("myLogFile.log"));
        }
    }
}
