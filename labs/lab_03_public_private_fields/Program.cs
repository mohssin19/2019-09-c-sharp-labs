using System;

namespace lab_03_public_private_fields
{
    class Program
    {
        static void Main(string[] args)
        {
            var person01 = new Person();
            person01.Name = "Fantasia";

            person01.SetNINO("AS134");
            //print nino
            string output = person01.GetNINO();
            Console.WriteLine(output);
        }
    }

    class Person
    {
        private string NINO;
        public string Name;

        //getters and setters to read & write private data

        public string GetNINO()
        {
            return this.NINO;
        }


        //parameter is the data passed into the method (string nino e.g)
        public void SetNINO(string nino)
        {
            this.NINO = nino;
        }


    }
}
