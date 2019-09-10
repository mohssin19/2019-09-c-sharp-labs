using System;

namespace lab_20_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array01 = new int[10]; // size 10
            int[] arrayList = new int[] { 1, 2, 3, 4, 5 };
            string[] stringLiteral = new string[] {"one", "two", "three"};

            //2d array
            int[,] Array2D = new int[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Array2D[i, j] = i * i * j * j;
                }
            }
            int sum = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    sum+= Array2D[i,j];
                }
            }
            Console.WriteLine(sum);


            // 3d array
            int[,,] Cube3D = new int[10, 10, 10];
            
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    
                    for (int k = 0; k < 10; k++)
                    {
                        Cube3D[i, j, k] = i * i * j * j*k*k;
                    }
                }
            }

            int sum1 = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {

                    for (int k = 0; k < 10; k++)
                    {
                        sum1 += Cube3D[i, j, k];
                    }
                }
               
            }
                Console.WriteLine(sum1);


            int[][] myJaggedArray = new int[10][];

            myJaggedArray[0] = new int[5];
            Console.WriteLine(myJaggedArray[0].Length); //5 
        }
    }
}
