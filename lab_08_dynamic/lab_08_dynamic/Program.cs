using System;

namespace lab_08_dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            object o = 10;
            Console.WriteLine(o);
            Console.WriteLine(o.GetType());

            o = "a string";
            Console.WriteLine(o);
            Console.WriteLine(o.GetType());

            o = new int[1, 2, 3];

            Console.WriteLine(o);
            Console.WriteLine(o.GetType());

            dynamic objt2 = 10;
            objt2 = "a string";
            objt2 = new int[1, 2, 3];

            Console.WriteLine(objt2);
            Console.WriteLine(objt2.GetType());
        }
    }
}
