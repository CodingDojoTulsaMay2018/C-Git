using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human frank = new Human("Frank",2,4,6,8);
            Human mike = new Human("Mike",5,6,12,100);

            frank.Attack(mike,frank.strength);

            System.Console.WriteLine(mike.health);
            frank.Attack("5",1);

        }
    }
}
