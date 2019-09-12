using System;

namespace lab_25_Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            //integers
            byte bmin = 0;
            byte bmax = 255;
            byte b_in_binary = 0b_00000000;  //0
            byte bman_in_binary = 0b_11111111; //255

            byte bmin_in_hex = 0x_0000;
            byte bmax_in_hex = 0x_ff;  // f=1111 which converts to 15 in decimal

            //byte bnegative_is_invalid = -1;

            // letters are also stored as numbers
            char letter_01 = 'a';
            Console.WriteLine(letter_01);
            Console.WriteLine((int)letter_01);

            // be aware that a string is stored in an array of charecters

            string s = "Hello";
            char[] s2 = "Hello".ToCharArray();

            Console.WriteLine($"First letter has an Index 0 ie {s[0]}");

            // whole numbers
            // int
            var numberOfAnyType = 27;
            // int is 32 bits
            // but! one bit stored the 'sign' which is either + or -
            // so int has 31 bits for number storage
            Console.WriteLine(int.MaxValue);
            Console.WriteLine(int.MinValue);

            // SHORT
            short short01 = 25; //16 bits
            //LONG
            long long01 = 2345234523452345; // 64 bit

            short short02 = 12345;
            int int01 = 1234567890;
            long long02 = 1234567890123456789L;

            //DECIMAL
            //float 32 bit
            float f = 1.23f;
            //double 64 bit
            double double01 = 1.23;
            //decimal 128 bit
            decimal decimal01 = 1.23M;

            double total = 0;
            for (int i = 0; i < 8192; i++)
            {
                total += 0.7;
            }
            Console.WriteLine(total);

            decimal total2 = 0M;
            for (int i = 0; i < 8192; i++)
            {
                total2 += 0.7M;
            }
            Console.WriteLine(total2);

            //positive numbers ONLY
            uint positiveinteger = 500;
            Console.WriteLine(uint.MaxValue); // 2 to power of 32

            //Operators

            // a + b = c     Expressions
            // a, b      Operands
            // +        Operator

            //Unary (one input)

            //Increment
            int x = 10;
            x++;
            ++x;
            // both of the above add 1
            // in general just use x++; and use of possible on a seperate line
            int y = 1000;
            int z1 = y++;
            int z2 = ++y;
            Console.WriteLine(z1);              // z1= 1000 then increment y1 to 1001
            Console.WriteLine(z2);              // z2= (increments the first to 1000)

            //NOT
            Console.WriteLine(!true); //false
            Console.WriteLine(!!true); // true

            // binary (two inputs)
            // modulus 
            // integer division : take care because the 1st int/int = int


            // Ternary Operator
            // if (condition) ? return this if true : return this if false;
            Console.WriteLine((10 > 4)? " high " : " low " );
            Console.WriteLine((10 < 4) ? " high " : " low ");

            //Nullable
            int number = 100;
            int? number2 = 1000;
            // number 2 is usefull if we read from a database and its possible that the box is blank 
            // so it returns null
            number2 = null;

            // null coalesce operator : 

            // if value then return value else 
            Console.WriteLine("somevalue"??"returnthisifnull");
            Console.WriteLine(null??"returnthisifnull");

            // Default value
            int somenumber = default; // assign 0
            int? somenumber2 = default; // null
            if (somenumber2 == null) Console.WriteLine("its nulls");


        }
    }
}
