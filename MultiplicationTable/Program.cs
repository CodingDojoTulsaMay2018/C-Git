using System;

namespace MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int [,] multiplyTable = new int[11,11];
            for(int row =1;row<11;row++){
                Console.WriteLine("");
                for(int col = 1; col <11;col++){
                    multiplyTable[row,col]= row*col;
                    Console.Write(multiplyTable[row,col] +"  |");
                }


            }



        }
    }
}
