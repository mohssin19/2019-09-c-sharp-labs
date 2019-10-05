using System;

namespace lab_32_Events
{
    class Program
    {
        public delegate void MyDelegate();

        public static event  MyDelegate MyEvent;

        static void Main(string[] args)
        {
            MyEvent += MethodA; // += Adds a method
            MyEvent += MethodB;
            MyEvent += MethodC;

            MyEvent -= MethodA; // -= Removes a method
            MyEvent();
        }




        static void MethodA() { Console.WriteLine("Method A"); }
        static void MethodB() { Console.WriteLine("Method B"); }
        static void MethodC() { Console.WriteLine("Method C"); }
    }
}
