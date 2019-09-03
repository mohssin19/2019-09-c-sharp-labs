using System;

namespace lab_06_inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new Dog();
            d.name = "fido";
            var labrador01 = new Labrador();
            labrador01.name = "MansBestFriend";
            labrador01.Age = 2;
            Console.WriteLine($"{labrador01.name}{labrador01.Age}");
        }
    }
    class Dog {
        public string name { get; set; }
    }

    class Labrador : Dog {
        public int Age { get; set; }
    }
}
