using System;

namespace Fundamentals1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!"); //Prints values from 1 to 255
            // for (int i = 1;i <=255;i++){

            //     Console.WriteLine(i);
            // }
            // for (int i = 1;i<=100;i++){
            //     if (i % 3 == 0 || i % 5 == 0){
            //         Console.WriteLine(i);
            //     }

            // }
            // for (int i = 1;i<=100;i++){
            //     if (i % 3 == 0){
            //         Console.WriteLine("{0} Fizz", i);
            //     }
            //     if(i % 5 == 0){
            //         Console.WriteLine("{0} Buzz",i);
            //     } 
            //     if (i % 5 == 0 && i % 3 ==0)  
            //         Console.WriteLine("{0} FizzBuzz",i);            

            // }

            // for (int i = 1;i<=100;i++){
            //     int f  = i / 3;
            //     int b  = i /5;
            //     if (f*3 -i == 0){
            //         Console.WriteLine("{0} Fizz", i);
            //     }
            //     if (b*5 -i == 0){
            //         Console.WriteLine("{0} Buzz", i);
            //     }
            //     if ((b*5 -i == 0) && (f*3 -i == 0) )
            //         Console.WriteLine("{0} FizzBuzz", i);

            // }

            Random rand = new Random();
            for(int val = 0; val < 10; val++)
            {
                //Prints the next random value between 2 and 8
                int randomnumber = (rand.Next(2,8));
                if (randomnumber == 2){
                    Console.WriteLine("Two {0}", randomnumber);
                }
                if (randomnumber == 3){
                    Console.WriteLine("Three {0}", randomnumber);
                }
                 if (randomnumber == 4){
                    Console.WriteLine("Four {0}", randomnumber);
                }               
                if (randomnumber == 5){
                    Console.WriteLine("Five {0}", randomnumber);
                }
                if (randomnumber == 6){
                    Console.WriteLine("Six {0}", randomnumber);
                }
                if (randomnumber == 7){
                    Console.WriteLine("Seven {0}", randomnumber);
                }
                if (randomnumber == 8){
                    Console.WriteLine("Eight {0}", randomnumber);
                }               

            }




        }
    }
}
