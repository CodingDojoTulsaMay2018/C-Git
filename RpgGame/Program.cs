using System;

namespace RpgGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Human frank = new Human("Frank",2,4,6);
            // System.Console.WriteLine(frank.health);
            Human mike = new Human("Mike",2,4,6,51);
            // System.Console.WriteLine(mike.health);
            // System.Console.WriteLine(mike.health);
            // frank.attack(mike);
            // System.Console.WriteLine(mike.health);
            Wizard harry = new Wizard("Harry");
            Wizard gandalf = new Wizard("Gandalf");          
            harry.heal();           
            harry.fireball(gandalf);
            Ninja aiden = new Ninja("Aiden");
            // aiden.stealHealth(harry);          
            // aiden.get_away();
            Samurai ryan = new Samurai("Ryan");
            // ryan.deathBlow(mike);
            // ryan.deathBlow(frank);
            System.Console.WriteLine(ryan.health);
            harry.fireball(ryan);
            System.Console.WriteLine(ryan.health);
            ryan.meditate();
            System.Console.WriteLine(ryan.health);
            System.Console.WriteLine(Samurai.activeCount);


           

            
            
 

        }
    }
}
