using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_mega_OOP_App
{
    class Program
    {
        static void Main(string[] args)
        {
            var k = new child("Kieran",10);
            k.DoThis();
            k.DoThat();
            Console.WriteLine(k.maybeDoThis());
            Console.ReadKey();


        }
    }
    interface IDoThis
    {
        void DoThis();
    }

    interface IDoThat
    {
        void DoThat();
    }

   abstract class Parent : IDoThis, IDoThat

    {
        // private
        private int ID = 001;
        //protected
        protected string Name { get; set; }
        // internal 
        internal int Age { get; set; }

        public abstract string maybeDoThis(); // ABSTRACT method

        

        // interface usage
        public virtual void DoThis() { Console.WriteLine("I'm Doing This"); } // using POLYMORPHISM
        public void DoThat() { Console.WriteLine("I'm Doing That"); }

    }

    class child : Parent
        
    {

        public child() { }      // always use a blank construnctor for default with no args
        public child(string name, int age) // constructor for name and age linking to parent class
        {
            Name = name;
            Age = age;
        }

        public override void DoThis()
        {
            Console.WriteLine(" virtual has been overrun");
        }

        public override string maybeDoThis()  // 
        {
            return("maybe doing this"); 
        }
    }
}
