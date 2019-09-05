using System;

namespace lab_15_b_abstact_class
{
    class Program
    {
        static void Main(string[] args)
        {
            string x = "Hello World";
            if(x.StartsWith("Hello"))
            {
                Console.WriteLine("world");
            }
            x = x.AmazingExtraStringMehtod();
            Console.WriteLine(x);
        }
    }

    public static class AddingToStrings
    {
        public static string AmazingExtraStringMehtod(this string s)
        {
            s = s + "--> add your comment";
            return s;
        }
    }

   
}
