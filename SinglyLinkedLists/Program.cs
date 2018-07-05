using System;

namespace SinglyLinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedLists list = new SinglyLinkedLists();
         
            list.add(1);
            list.add(2);
            list.add(3);
            list.add(4);
            // System.Console.WriteLine(list.head.value);
            // System.Console.WriteLine(list.head.next.value);
            list.printValues();
            System.Console.WriteLine("***********************");
            list.removeEnd();
            list.printValues();
        }
    }
}
