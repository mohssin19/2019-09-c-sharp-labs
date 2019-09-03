using System;

namespace lab_04_class_summary
{
    class Program
    {
        static void Main(string[] args)
        {
            //create an instance 
            // console readline to input data from user
            var human01 = new Human();
            Console.WriteLine("Enter your name: ");
            human01.SetName(Console.ReadLine());
            Console.WriteLine($" your name is {human01.GetName()}");
        }
    }

    //Create a class with public and private fields (get and set)
    class Human
    {
        private string Name;
        private int Age;
        private int height;

        public string GetName()
        {
            return this.Name;
        }

        public void SetName(string name)
        {
            this.Name = name;
        }
    }

}
        
