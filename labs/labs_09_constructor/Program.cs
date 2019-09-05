using System;

namespace labs_09_constructor
{
    class Program
    {
        static void Main(string[] args)
        {
            var merc01 = new Mercedes("chassis1234abc", "silver", 2500); // calling default constructor
            var merc02 = new Mercedes();

            var aclass01 = new Aclass("chasssis234bcd", "black", 3000);


        }
    }

    class Mercedes
    {
        protected string engineChassisID; // no access in new merc, gives access @ point of construction
        public string color { get; set; }

        public int length { get; set; }

        public Mercedes() // blank expilicit code it (default) for merc 02
        {

        }

        public Mercedes(string engineChassisID, string color, int length)  // default constructor here
        {
            this.engineChassisID = engineChassisID;
            this.color = color;
            this.length = length;
        }
    }
    
    class Aclass : Mercedes
    {
        public Aclass()
        {

        }
        public Aclass(string engineChassisID, string colour, int lenght)
        {
            this.engineChassisID = engineChassisID;
            this.color = color;
            this.length = length;
        }
    }

    class A104 : Aclass
    {
        // different constructor calling parent or base constructors

        public A104(string engineChassisID, string colour, int lenght = 1000) : base ( engineChassisID, colour, lenght) { }
        
    }
}
