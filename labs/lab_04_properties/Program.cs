using System;

namespace lab_04_properties
{
    class Program
    {
        static void Main(string[] args)
        {
            var rabbit = new Rabbit();
            rabbit.Name = "Cute01";
            rabbit.Age = -10;
            Console.WriteLine(rabbit.Age);
        }
    }

    class Rabbit
    {
        private int _bloodType; //Fields
        private int _age;

        public string Name { get; set; } // auto implemented property

        public int Age {
            get
            {
                return this._age;
            }
            set
            {
                if (value > 0)
                {
                    this._age = value;
                }
            }
        }
    }
}
