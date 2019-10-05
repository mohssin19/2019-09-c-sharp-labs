using System;

namespace lab_33_oop_events
{
    class Program
    {
        static void Main(string[] args)
        {
            var Mohssin = new Child();
            Mohssin.Name = "Mohssin";
            for (int i = 0; i < 10; i++)
            {
                Mohssin.Grow($"WildParty For year{i}");
            }
            


        }
    }

    class Child
    {
        public delegate int BirthdayDelegate(string TypeOfParty);
        public event BirthdayDelegate HaveABirthday;

        public string Name { get; set; }
        public int Age { get; set; }

        public Child()
        {
            this.Age = 0;
            Console.WriteLine("Congrats !! Great Baby");
            HaveABirthday += Celebrate;
        }

        int Celebrate(string TypeOfParty)
        {
            Age++; // One year older
            Console.WriteLine($"celbrating birthday age is : {this.Age} : {TypeOfParty}");
            return Age;
        }

        public void Grow(string TypeofParty)
        {
           int AgeNow = HaveABirthday(TypeofParty);
        }
    }
}
