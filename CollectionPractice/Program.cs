using System;
using System.Collections.Generic;
namespace CollectionPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("*********************Arrays***********************");
            int[] numArray = new int[]{1,2,3,4,6};
            string[] nameArray = new string []{"Frank", "Tom", "Troy"};
            bool[] boolArray = new bool[]{true,false,true,false,true,false,true,false,true,false};

            Console.WriteLine("*********************LIsts***********************");
            List<string> flavors = new List<string>();
            flavors.Add("Vanilla");
            flavors.Add("Chocolate");
            flavors.Add("Strawberry");
            flavors.Add("Cherry");
            flavors.Add("Cookiedough");
            Console.WriteLine("Number of flavors " + flavors.Count);


            Console.WriteLine(flavors[2]);
            flavors.Remove(flavors[2]);
            Console.WriteLine(flavors.Count);
            for (var idx = 0; idx < flavors.Count; idx++)
            {
            Console.WriteLine("-" + flavors[idx]);
            }
            Console.WriteLine("*********************Dictionary***********************");



            Dictionary<string,string> namesAndFlavors = new Dictionary<string,string>();
            namesAndFlavors.Add("Frank", null);
            namesAndFlavors.Add("Tom", null);
            namesAndFlavors.Add("Troy", null);



            Random rand = new Random();
            List<string> keys = new List<string>(namesAndFlavors.Keys);

            foreach(string key in keys){

                int randomnumber = (rand.Next(flavors.Count));
                string flavor = flavors[randomnumber];
                namesAndFlavors[key] = flavor;
            }
            foreach (KeyValuePair<string,string> entry in namesAndFlavors){
            
            Console.WriteLine(entry.Key + " - " + entry.Value);









            
            

        }
    }
}
