using System;

namespace lab_10_overloading
{
    class Program
    {
        static void Main(string[] args)
        {
            Method01();
            Method01(100);
            Method01("string");
            Method01(100, "string");
        }
        static void Method01 () { Console.WriteLine("blank"); }

        static void Method01(int x) { Method01(x, "SomeValue"); }

        static void Method01(string y) { Console.WriteLine(y); }


        static void Method01(int x, string y) { Console.WriteLine(x + y); }
    }
}
