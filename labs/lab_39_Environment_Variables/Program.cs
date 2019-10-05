using System;
using System.Collections.Generic;
using System.Collections;

namespace lab_39_Environment_Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = Environment.GetEnvironmentVariables();


            foreach (DictionaryEntry item in Environment.GetEnvironmentVariables())
            {
                Console.WriteLine($"key: {item.Key} ',' {item.Value}");
            }
            Console.WriteLine(Environment.GetEnvironmentVariable("WinDir"));

            Environment.SetEnvironmentVariable("Secret Password", "123");

            Console.WriteLine(Environment.GetEnvironmentVariable("Secret Password"));
        }
    }
}
