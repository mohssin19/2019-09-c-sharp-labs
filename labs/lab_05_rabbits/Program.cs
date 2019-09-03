using System;
using System.Collections.Generic;

namespace lab_05_rabbits
{
    class Program
    {
        static List<Rabbit> rabbits = new List<Rabbit>();
        static void Main(string[] args)
        {
            // create a lab



            // count 1 to 10



            // create Rabbits



            // name = "Rabbit" + 0 + i    Rabbit01, Rabbit02,  
            // age = i
            // add to list of rabbits
            // print out list at end 

            

            
            for (int i = 0; i < 10; i++)
            {
                var r = new Rabbit();
                r.age = i;
                //r.name = $"Rabbit0{i}";
                if (i < 10)
                {
                    r.name = $"Rabbit0{i}"; 
                }
                else
                {
                    r.name = $"Rabbit{i}";
                }

                rabbits.Add(r);
               
            }
            // for each 
        }
        class Rabbit
        {
            public string name { get; set; }

            public int age { get; set; }
        }
    }

    
}
