using System;

namespace PhoneAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Nokia elevenHundred = new Nokia("1100",60,"Metro PCS", "Ringgg ring ringggg");
            elevenHundred.DisplayInfo();
            System.Console.WriteLine(elevenHundred.Ring());
            System.Console.WriteLine(elevenHundred.Unlock());

            Galaxy s8 = new Galaxy("s8",100,"T-mobile", "Ringgg ring ringggg");
            System.Console.WriteLine(s8.Ring());
            System.Console.WriteLine(s8.Unlock());
           

            // Galaxy s8 = new Galaxy("s8", 100, "T-mobile", )




        }
    }
}
