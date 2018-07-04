using System;
using System.Collections.Generic;
namespace Boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int num1 =10;
            object obj1 =num1;  
            List<object> box = new List<object>();


            box.Add(7);
            box.Add(28);
            box.Add(-1);
            box.Add(true);
            box.Add("chair");
            var sum =0;
            foreach (var item in box)
            {   
                if(item is int){
                    int newInt= (int)item;
                    sum += newInt;
                }
            }
            System.Console.WriteLine(sum);
        }
    }
}
