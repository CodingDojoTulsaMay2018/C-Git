using System;

namespace AccessModifiers
{

    public class Person
    {
        private DateTime _birthdate; //This is what you want to keep hidden.

        public void SetBirthdate(DateTime birthdate) //You are forced to call a method to Get.
        {
            _birthdate = birthdate;
        }
        public DateTime GerBirthdate() //You are forced to call a method to Get.
        {
            return _birthdate;
        }

    }

}