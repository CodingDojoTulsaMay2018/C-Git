using System;

namespace AccessModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();
            person.SetBirthdate(new DateTime(1975,9,11));
            System.Console.WriteLine(person.GerBirthdate());


            var person2 = new Person2();
            person2.Birthdate = new DateTime(1976,3,17);
            System.Console.WriteLine(person2.Age);
            
            
        }
    }
}
