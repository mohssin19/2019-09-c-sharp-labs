using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace justdoit
{

    class Program
    {
        //static List<Rabbit> rabbits = new List<Rabbit>();
        static void Main(string[] args)
        {
            just_do_it_11_rabbit_explosion.Rabbit_Exponential_Growth(100);
        }

    }

    class Rabbit
    {
        public string Name;
        public int Age = 0;

        public string GetName()
        {
            return this.Name;
        }

        public void SetName(string name)
        {
            this.Name = name;
        }
    public string GetAge()
    {
        return this.Name;
    }

    public void SetAge(int age)
    {
        this.Age = age;
    }
}

public class just_do_it_11_rabbit_explosion
{
       static List<Rabbit> rabbits = new List<Rabbit>();
       public static int Rabbit_Exponential_Growth(int popLimit)
    {
                //for (int i = 0; i < 51; )
                //{
                //    var r = new Rabbit();

                //    r.Name = $"Rabbit0{i}";

                //    Console.WriteLine(r.Name);

                //    rabbits.Add(r);

                //    //if (rabbits.Count > 30 )
                //    //{
                //    //    Console.WriteLine("Rabbit population limit exceeded");
                //    //    break;
                //    //}
                //    //Thread.Sleep(200);

                
                var initialRabbit = new Rabbit();
                rabbits.Add(initialRabbit);
                var fileName = $"output - {DateTime.Now.ToLongDateString()}.log";
                File.WriteAllText(fileName, "RabbitsLog");
                var s = new Stopwatch();



                //int popLimit = 100;

                Console.WriteLine($"Rabbit added. Current population is {rabbits.Count}.");
                s.Start();
                int years = 0;
                while (rabbits.Count < popLimit)
                {
                    var rabbit = new Rabbit();

                    int currentPop = rabbits.Count;
                    
                    for (int i = 0; i < (currentPop); i++)
                    {
                        rabbits[i].Age++;
                        //rabbits.Add(rabbit);
                        if (rabbits[i].Age >= 3)
                        {
                            if (rabbits.Count < popLimit)
                            {
                                rabbits.Add(rabbit);
                                Console.WriteLine($"rabit{rabbits[rabbits.Count - 1]} created @ {DateTime.Now}");


                            }
                            else
                            {
                                break;
                            }
                            
                        }

                    
                    }
                    years++;

                    //Thread.Sleep(200);

                    Console.WriteLine($"Rabbit added. Current population is {rabbits.Count}.");
                    s.Stop();
                    Console.WriteLine(s.Elapsed);
                    Console.WriteLine(s.ElapsedMilliseconds);
                    Console.WriteLine(s.ElapsedTicks);
                }
            return years;


            }
        }
    }

