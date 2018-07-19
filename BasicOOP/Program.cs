using System;

namespace BasicOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle myCar = new Vehicle(3);
            Vehicle myBike = new Vehicle(1);

            System.Console.WriteLine(myCar.numPassenger);
            
            myBike.Move(1.3);
            myCar.Move(4.5);
            System.Console.WriteLine("My bike went {0} miles & my car went {1} miles",myBike.distance,myCar.distance);
        }
    }
}
