using System;

namespace lab_02_class
{
    class Program
    {
        static void Main(string[] args)
        {
            // use class and create new dog object called an instance of a class

            var dog01 = new Dog();
            dog01.Name = "Scooby";
            dog01.Age = 1;
            dog01.height = 400;


            // grow our dog
            dog01.Grow();
            //print new age and hright
            Console.WriteLine(" Age is " + dog01.Age + " Height is " + dog01.height);
            dog01.Grow();
            Console.WriteLine($"Age is {dog01.Age} and height is {dog01.height}");

        }
    }
}

// CREATE A CLASS HERE OR NEW CLASS FILE (NAMESPACE IS THE IMPORTANT FACTOR)
class Dog
{
    public string Name;
    public int Age;
    public int height;

    public void Grow()  // have method return nothing 
    {
        // let computer know is it returning any value
        //no is VOID
        // yes then declare type == int, string etc.
        this.Age++;
        this.height += 10;



    }

}

