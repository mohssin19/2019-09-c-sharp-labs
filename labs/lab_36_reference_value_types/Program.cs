using System;
using System.Collections.Generic;
namespace lab_36_reference_value_types
{
    class Program
    {
        static void Main(string[] args)
        {
            // PRIMITIVE TYPE : INT BOOL CHAR STRUCT (STORED FAST STACK MEMORY)
            // values stored with declaration in live, fast code.
            // destroy immediately as well
            // == VALUE TYPES as VALUE in stack memory with declaration
            // var x=10; x and 10 stored on stack
            // copy of a vlues type is independant 
            double x = 10;
            double y = x;
            x = 1000;
            y = 3333;
            Console.WriteLine($" x is {x} and y is {y}");
            

            
            // pass x and y into method
            DoThis(x, y);
            Console.WriteLine($"x is {x} y is {y}");


            // pass into method ref to change perm
            DoThisPermenantly(ref x, ref y);
            Console.WriteLine($" x is {x}  y is {y}");


            // reference types
            // value types are primitives are eg. int held on fast stack
            // reference types are large objects 
            // shortcuts = pointer held on fast stack
            // actual object held on the slower heap (larger heap)
            // stack
            // int x = 10 
            // list<string> myList----------- points to data{here 1 2 }

            // COPY reference type, then default you only copy the pointer
            int[] myArray = new int[] { 100, 200, 300 };
            var myArray2 = myArray; // copy pointer only NOT A NEW OBJECT
            myArray[2] = 5000;
            myArray[1] = 14000;
            Console.WriteLine(string.Join(",", myArray));
            Console.WriteLine(string.Join(",", myArray2));

            //REFERENCE TYPES NATURALLY TREATED AS GLOBAL WHEN PASSED INTO A METHOD
            var myList = new List<string>() { "first", "second" };
            DoThisList(myList);
            Console.WriteLine(String.Join(",",myList));
        }

        static void DoThis(double x, double y)
        {
            x = x * y;
            y = y * y * y;

            Console.WriteLine($"x is {x} y is {y}");
        
        }
        
        static void DoThisPermenantly(ref double x, ref double y)
        {
            x = x * y;
            y = y * y * y;

            Console.WriteLine($" ref x is {x} ref y is {y}");

        }

        static void DoThisList(List<string> list)
        {
            list.Add("hello");
            list.Add("hello again");
        }

    }
}
// summary : stack  primitives/value types/pointers (to heap) fast  instant disposal

            //heap reference typoes             slower  garbage collection at intervals
