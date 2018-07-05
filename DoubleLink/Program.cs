using System;

namespace DoubleLink
{
    class Program
    {
        static void Main(string[] args)
        {
           
            DoubleLinkList list = new DoubleLinkList();
           
            list.add(0);
            list.add(1);
            list.add(2);
            list.add(3);
            list.add(4);
            // System.Console.WriteLine("*************");
            

            // list.remove(2);
            // System.Console.WriteLine("*************");
            list.printValues();
            System.Console.WriteLine("*************");
            list.reverse();
            System.Console.WriteLine("*************");
            list.printValues();
          
            // System.Console.WriteLine(list.head.value);
            // System.Console.WriteLine(list.tail.value);
        }
    }
}
