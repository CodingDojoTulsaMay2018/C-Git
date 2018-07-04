using System;
using System.Collections.Generic;

namespace Basic13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // printTo255();
            // oddTo255();
            // printSum();
            // var testArray = new int[]{1,2,3,4};
            // int[] intArray = new int[4]{1,2,3,4};
            // iterateArray(intArray);
            // findMax();
            // getAverage();
            // oddArray();
            // greaterThanY();
            // squareValues();
            // removeNeg();
            // minMaxAvg();
            // shiftArray();
            numToString();
        }
        static void printTo255()
        {
            for(var i =1;i<=255;i++){
                System.Console.WriteLine(i);
            }
        }
        static void oddTo255()
        {
            for(var i =1;i<=255;i++){
                if(i%2 == 1){
                    System.Console.WriteLine(i);
                }
            }
        }
        static void printSum()
        {
            var sum =0;
            for(var i =1;i<=255;i++){
                System.Console.WriteLine("New Number: " + i);
                sum +=i;
                System.Console.WriteLine(sum);
            }
        }
        static void iterateArray(int[] x)
        {
            
            foreach(int numbers in x){
                System.Console.WriteLine(numbers);
            }
        }
        static void findMax()
        {
            int[] maxArray = new int[5]{1,0,3,-1,6};
            var max = maxArray[0];
            foreach(int val in maxArray)
            {
                if (val > max){
                    max = val;
                }
            }
            System.Console.WriteLine(max);

        }
        static void getAverage()
        {
            var sum =0f;
            int[] avgArray = new int[5]{30,5,4,6,3};
            foreach(int val in avgArray)
            {
                sum += val;
            }
        System.Console.WriteLine(sum/avgArray.Length);
        }
        static void oddArray()
        {
            List<int> oddNumbers = new List<int>();

            for(var i =1;i<=255;i++){
                if(i%2 == 1){
                    oddNumbers.Add(i);
                }
                
            }
            int[] oddNums = oddNumbers.ToArray();
            foreach(int val in oddNums){
                System.Console.WriteLine(val);
            }
        }

        static void greaterThanY()
        {
            var y = 4;
            var count = 0;
            int[] Array = new int[5]{30,5,1,6,4};
            foreach(var val in Array){
                if (val > y){
                    count++;
                }
            }
            System.Console.WriteLine(count);
        }

        static void squareValues()
        {
            int[] sqArray = {3,5,1,6,4};
            for(var i =0;i<sqArray.Length;i++){
                sqArray[i] = sqArray[i] * sqArray[i];
                System.Console.WriteLine(sqArray[i]);
            }
            
        }

        static void removeNeg()
        {
            int[] negArray = {3,-5,1,-6,4};
            for(var i =0;i<negArray.Length;i++){
                if(negArray[i]<0){
                    negArray[i]=0;
                }
            }
            foreach(int val in negArray){
                System.Console.WriteLine(val);
            }
        }
        static void minMaxAvg()
        {
            int[] Array = {3,-5,1,-6,4,7,22};
            var max = Array[0];
            var min = Array[0];
            var sum = 0;
            for(var i =0;i<Array.Length;i++){
                if(Array[i]>max){
                    max = Array[i];
                }
                if(Array[i]<min){
                    min = Array[i];
                }
                sum += Array[i];
            }
            System.Console.WriteLine("Max: " + max);
            System.Console.WriteLine("Min: " + min);
            System.Console.WriteLine("Avg: " + sum/Array.Length);
        }
        static void shiftArray()
        {
            int[] Array = {3,-5,1,-6,4,7,22};
            for(var i =0;i<Array.Length;i++){
                if(i < Array.Length-1)
                {
                Array[i] = Array[i+1];
                }
                else{
                    Array[i]=0;
                }
            }
            foreach(int val in Array){
                System.Console.WriteLine(val);
            }
        }

        static void numToString()
        {
            List<string> newList = new List<string>();
            int[] numArray = {3,-5,1,-6,4,7,22};
            for(var i =0;i<numArray.Length;i++){
                if(numArray[i] <0){
                    
                   newList.Add("Dojo"); 
                }
                else{
                    newList.Add(numArray[i].ToString());
                }
            }
            string[] dojoInts = newList.ToArray();
            foreach(string val in dojoInts){
                System.Console.WriteLine(val);
            }

        }
        


        
    }
}
