using System;

namespace lab_15_abstact_class
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    abstract public class Holiday
    {
        public abstract void Travel();

        public void Places() { Console.WriteLine("visiting vienna, salzburg"); }

        public void Activities() { Console.WriteLine("Skiing, fishing"); }
    }

    public class HolidayWithTravel : Holiday
    {
        public override void Travel() { Console.WriteLine("By Train Eurostar"); }
    }
}
