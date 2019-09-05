using System;

namespace lab_11_polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new parent();
            p.HaveABirthday();
            var c = new child();
            c.HaveABirthday();
            for (int i = 0; i < 10; i++)
            {
                p.HaveABirthday();
                c.HaveABirthday();
                Console.WriteLine($"Parent is age{p.Age} child is age {c.Age}");

            }


        }
    }

    class parent
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public virtual void HaveABirthday()
        {
            Age+=5;
        }

        public parent() {}
        public parent(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }
    }

    class child : parent {

        public override void HaveABirthday()
        {
            Age += 2;
            //base.HaveABirthday();
        }

    }
    
}
