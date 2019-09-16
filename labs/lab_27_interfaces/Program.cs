using System;
using external;

namespace lab_27_interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
           

        }
    }
    class Parent
    {

    }

    class Child : Parent, IDoThis, IDoThat, IAlsoDoThis
    {
        public void DoThis() { Console.WriteLine("Do this"); }

        public void DoThat() { Console.WriteLine("Do That"); }

        public void AlsoDoThis() { Console.WriteLine("Also do this"); }
    }

    interface IDoThis
    {
        void DoThis();
    }

    interface IDoThat
    {
        void DoThat();
    }


}

namespace external
{
    interface IAlsoDoThis
    {
        void AlsoDoThis();
    }

}
