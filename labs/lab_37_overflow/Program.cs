using System;

namespace lab_37_overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            short s = 12345;
            int i = 1234567890;
            long l = 1234567890123456789;
            float f = 12345678901234567891234567890.12345678901234567891234567890F;
            double d = 12345678901234567891234567890123456789123456789123456789123456789.12345678901234567891234567890;
            decimal dd = 12345678901234567891234567890.123456789012345678901234567890123456M;

            Console.WriteLine(f);
            Console.WriteLine(d);
            Console.WriteLine(dd);

            unchecked
            {
                // integers maximum
                Console.WriteLine(int.MaxValue);
                int bigInt = int.MaxValue;
                bigInt += 1;
                Console.WriteLine(bigInt);
                bigInt += 1;
                Console.WriteLine(bigInt);
                bigInt += 1;
                Console.WriteLine(bigInt);
                bigInt += 1;
                Console.WriteLine(bigInt);
                bigInt += 1;
                Console.WriteLine(bigInt);
                bigInt += 1;
            }

            DoThis();


        }
        static int counter = 0;
        static void DoThis()
        {
            counter++;

            Console.WriteLine("DOING THIS" + counter);

            DoThis();
        }
    }
}
