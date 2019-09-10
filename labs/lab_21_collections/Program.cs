using System;
using System.Collections;
using System.Collections.Generic;

namespace lab_21_collections
{
    class Program
    {
        static void Main(string[] args)
        {
            // dictionary
            //var dictionary = new Dictionary<int, string>();
            //dictionary.Add(0, "hi");
            //dictionary.Add(1, "hi"); // exception

            //dictionary.TryAdd(2, "hi there");

            //// get values
            //// ,-10 gives a space width of number when displaying data
            //foreach (KeyValuePair<int,string> item in dictionary)
            //{
            //    Console.WriteLine($"{item.Key,-10}{item.Value}");
            //}

            //queue
            var Queue = new Queue<int>();
            Queue.Enqueue(1);
            Queue.Enqueue(2);
            Queue.Enqueue(3);
            Queue.Enqueue(4);

            

            foreach (var item in Queue)
            {
                Console.WriteLine(item);
            }



            //stack
            var stack = new Stack<string>();
            stack.Push("hello");
            stack.Push("world");

            while (stack.Count != 0)
            {
                Console.WriteLine(stack.Peek());
                stack.Pop();
            }

            //list

            List<int> numbers = new List<int>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);

            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }

            //arraylist
            var arraylist = new ArrayList();
            arraylist.Add(1);
            arraylist.Add("yo");
            foreach (var item in arraylist)
            {
                Console.WriteLine(item.ToString());
            }

            //LinkedList
            var LinkedList = new LinkedList<int>();
            LinkedList.AddLast(5);
            LinkedList.AddLast(4);
            LinkedList.AddLast(3);

            foreach (var item in LinkedList)
            {
                Console.WriteLine(item.ToString());
            }

            //Hashset
            var Hashset = new HashSet<string>();
            Hashset.Add("test");
            Hashset.Add("this");
            Hashset.Add("now");

            foreach (var item in Hashset)
            {
                Console.WriteLine(item);
            }
        }
    }
}
