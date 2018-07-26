using System;

namespace AccessModifiers
{

    public class Person2
    {
        public DateTime Birthdate { get;set;}
        //This is exactly the same code as in Person.cs, but shorter. 

        //When it compiles the code, it will make everything for us.

        // 1. Csharp makes the private field like 'private DateTime _birthdate;'
        // 2. It also makes both the set & get methods.

        public int Age
        {
            get
            {
                var timeSpan = DateTime.Today - Birthdate;
                var years = timeSpan.Days/365;

                return years;
            }
        }
            
        
    }

}