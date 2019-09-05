using System;
using System.Diagnostics;

namespace lab_14_stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Stopwatch();
            s.Start();

            var counter = 0;
            for (int i = 0; i < 100_000_000; i++)
            {
                counter++;
            }


            s.Stop();
            Console.WriteLine(s.Elapsed + " Seconds");
            Console.WriteLine(s.ElapsedMilliseconds + " milliseconds");
            Console.WriteLine(s.ElapsedTicks + " Ticks are 10 - 7 seconds");

            
        }
    }
}
