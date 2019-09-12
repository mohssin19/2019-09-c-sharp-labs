using System;
using System.IO;


namespace lab_26_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            //ERROR : bank calculates interest correctly : programmer error
            //          in logic

            //EXCEPTION
            // when code crashes and program cant continue

            // handled == exception takes place inside a TRY block and handled in CATCH block && exception or not run the FINALLY block
            // unhandled == code crashes and you get an unhandled exception, progra, terminates uncleanly
            // compiler == RED LINE will not build syntax
            // runtime == other circumstances such as divide by 0
            int x = 10;
            int y = 0;
            //Console.WriteLine(x/y);

            try {
                // try any code which might produce an exception
                Console.WriteLine(x / y); //throws exception
            }

            catch (Exception e) {
                Console.WriteLine("Hey dont do that"); //
                Console.WriteLine(e.Data);
                Console.WriteLine(e.Message);
            }

            finally {
                Console.WriteLine("have fun");
            }

            // custome exceptions
            var myException = new Exception("Hey this is a custom exception");
            try
            {
                //Imagine engine is getting hot but has not burned out yet
                throw (myException);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //LARGE REAL WORLD APPLICATION
            //LAYERS OF NESTING MAIN : SUB : SUB.
            try
            {
                try
                {
                    try
                    {
                        throw (new Exception("Inner Exception - my code"));
                    }
                    catch
                    {
                        throw;
                    }
                }

                catch
                {
                    throw;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                File.WriteAllText("log.txt",$"CODE wrong again");
            }

            // types of exceptions

            try { }
            catch(DivideByZeroException) { Console.WriteLine("i said dont do that"); }
            catch(Exception e) { Console.WriteLine("all exceptions"); }
        }
    }
}
