using System;

namespace labs_07_methods
{
    class Program
    {
        static void Main(string[] args)
        {
            DoThis();
            DoThisAswell();


            void DoThis(){
                Console.WriteLine("im doing something");
            }

            CountNumbers(5000);  // y only
            CountNumbers(5000, 300); //

            OutParameters(10, 10, out int a);
            Console.WriteLine($"out parameter was {a}");


            TupleMethod();

            var tupleOutput = TupleMethod();
            Console.WriteLine($"{tupleOutput.x}, {tupleOutput.y}, {tupleOutput.z}");
        }

        static void DoThisAswell()
        {
            Console.WriteLine("something else??");
        }

        static void CountNumbers(int y, int x = 100)
        {
            Console.WriteLine(x * y);
        }

        static void OutParameters(int x, int y, out int z)
        {
            z = x * y; // will return as z
        }

        static (int x, string y, bool z) TupleMethod()
        {
            return (10, "hi", false);
        }
    }
    class Mammal
    {
        public int Age { get; set; }
        //instance method
        public void getolder() { Age++; }
    }
}
