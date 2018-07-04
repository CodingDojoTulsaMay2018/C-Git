using System;
using System.Collections.Generic;
namespace Puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            // RandomArray();
           
        //    var cointext = tossCoin();
        //    System.Console.WriteLine(cointext);

            // TossMultipleCoins(5);
            Names();

        }
        static void RandomArray()
        {
            
            int[] randomArray = new int[10];
            Random rand = new Random();
            for(int i =0;i<10;i++){
                randomArray[i] = rand.Next(5,26);
            }
            var max = randomArray[0];
            var min = randomArray[0];
            var sum = 0;
            foreach (var item in randomArray)
            {
                sum += item;
                if (item >max){
                    max = item;
                }
                if (item<min){
                min = item;
                }

            }            

            System.Console.WriteLine(sum);
            System.Console.WriteLine(max);
            System.Console.WriteLine(min);

        }

        static string tossCoin(){

            System.Console.WriteLine("Tossing a coin!");
            Random rand = new Random();
            var coin = rand.Next(1,3);
            var landedOn = "";
            // System.Console.WriteLine(coin);
            if(coin == 1){
                // System.Console.WriteLine("Heads");
                landedOn = "Heads";
            }
            else{
                // System.Console.WriteLine("Tails");
                landedOn = "Tails";
            }
        return (landedOn);
        }
        static double TossMultipleCoins(int num){
            // System.Console.WriteLine(num);
            var headCount = 0;
            var tailCount = 0;
            for(var i =0;i<num;i++){
               var coinSide= tossCoin();
               if(coinSide == "Heads"){
                   headCount++;
               }
               else{
                   tailCount++;
               }
               
            }
            System.Console.WriteLine(headCount);
            double ratio = headCount/num;
            return (ratio);
        }
        static void Names(){
            
            string[] stringArray = {"Todd","Tiffany","Charlie","Geneva","Sydney"};
            Random rand = new Random();
          
            
            for(var i =0;i<stringArray.Length;i++){
                // System.Console.WriteLine(stringArray[i]);
                var randomPosition = rand.Next(0,stringArray.Length);
                var temp = stringArray[i];
                stringArray[i] = stringArray[randomPosition];
                stringArray[randomPosition] = temp;
                
            }
            foreach (var name in stringArray)
            {
                System.Console.WriteLine(name);
            }
            

        }
      
      
        



    }
}
