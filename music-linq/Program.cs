using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();
  using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            // There is only one artist in this collection from Mount Vernon, what is their name and age?
            var foundArtist = from artist in Artists
            where artist.Hometown == "Mount Vernon"
            select new { name = artist.ArtistName, age = artist.Age };
            foreach(var artist in foundArtist)
            {
                Console.WriteLine($"{artist.name}, {artist.age}\n");
            }
            
            //Who is the youngest artist in our collection of artists?
            var youngestArtist = (from artist in Artists
            orderby artist.Age descending
            select artist.ArtistName).First();

            Console.WriteLine($"{youngestArtist}\n");

            //Display all artists with 'William' somewhere in their real name
            var withWilliam = Artists.Where(artist => artist.RealName.Contains("William"));
            foreach(var artist in withWilliam)
            {
                Console.Write($"{artist.RealName}, ");
                
            }
            Console.WriteLine("\n");

            //Display the 3 oldest artist from Atlanta
            var fromAtlanta = Artists.Where(artist => artist.Hometown == "Atlanta").OrderByDescending(artist => artist.Age).Take(3);
            foreach(var artist in fromAtlanta)
            {
                Console.Write($"{artist.ArtistName}, ");
            }
            Console.WriteLine("\n");

            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            // var combo = Artists.Join(Groups, a => a.GroupId, b => b.Id, (a,b) => new {a,b}).Any(a => a.Hometown != "New York City");

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            var wuTangClan = Groups.Where(g => g.GroupName == "Wu-Tang Clan").Join(Artists, g => g.Id, a => a.GroupId, (g,a) => new {a.ArtistName});
            foreach(var i in wuTangClan)
            {
                Console.Write($"{i.ArtistName}, ");
            }
        }
    }
}


            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            // var person = Artists.Where(a=>a.Hometown == "Mount Vernon");
            // foreach (var item in person)
            // {
            //     System.Console.WriteLine("********************");
            //     System.Console.WriteLine(item.ArtistName);
            //     System.Console.WriteLine(item.Age);
            //     System.Console.WriteLine("********************");
            // }
          

//    ******************************************************************************************             
            // var person = Artists.OrderByDescending(a=>a.Age).Last();
            // System.Console.WriteLine(person.ArtistName);

            //Who is the youngest artist in our collection of artists?
//    ******************************************************************************************  
            //Display all artists with 'William' somewhere in their real name
            
//    ******************************************************************************************  
            //Display the 3 oldest artist from Atlanta
//    ******************************************************************************************         
            // var persons =Artists.Where(a =>a.RealName.Contains("William"));
            // foreach (var item in persons)
            // {
            //    System.Console.WriteLine(item.RealName);
            // }
            //(Optional) Display the Group Name of all groups that have members that are not from New York City
         
            // var persons = 
            //     from a in Artists
            //     join g in Groups on a.GroupId
            //     equals g.Id 
            //     select new
            //     {
            //         Artists.GroupId = a .GroupId,
            //         GroupID = g.Id
            //     };
            

            // var query = 
            // (from g in Groups
            // join a in Artists.Where(a=>a.Hometown != "New York City")
            // on g.Id equals a.GroupId
            // select new {g.GroupName}).Distinct();


            //  foreach (var item in query)
            // {
            //     System.Console.WriteLine(item.GroupName);
            // }


                


            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'

            // var query2  = 
            // from g in Groups.Where(g=>g.GroupName == "Wu-Tang Clan")
            // join a in Artists on g.Id equals a.GroupId
            // select new {a.ArtistName};

            // foreach (var item in query2)
            // {
            //     System.Console.WriteLine(item.ArtistName);
            // 

            var beginDate = new DateTime(2015,1,1);
            // var now = DateTime.Now;
            // var today = DateTime;
            // System.Console.WriteLine(today,"Mm");
            // System.Console.WriteLine("Hour :" + now.Hour);
            // System.Console.WriteLine("Minute :" + now.Minute);

            // var tomorrow = now.AddDays(1);
            // var yesterday = now.AddDays(-4);
            // // int result = DateTime.Compare(yesterday,tomorrow);
            // int result = DateTime.Compare(yesterday,tomorrow);
            // System.Console.WriteLine(result);
            // int result = DateTime.Compare(t1,t2);
            // if t1 is less than t2 the result will be -1
            // if t1 is greater than t2 the result will be 1
            // if t1 is the same as t2 the result will be 0

            // System.Console.WriteLine(tomorrow);
            // System.Console.WriteLine(yesterday);


            // System.Console.WriteLine(now.ToLongDateString() + "   <----Long Date");
            // System.Console.WriteLine(now.ToShortDateString()+ "   <----Short Date");
            // System.Console.WriteLine(now.ToShortTimeString()+ "   <----Long Time");
            // System.Console.WriteLine(now.ToLongTimeString()+ "   <----Short Time");
            // System.Console.WriteLine(now.ToString()+ "   <-----To String");
            // System.Console.WriteLine(now.ToLongDateString()
            // DateTime CurrentTime  = DateTime.Now;
            // string date = today.ToString("MMMM d, yyyy");
            // System.Console.WriteLine(date);


            // System.Console.WriteLine(now.ToShortDateString("MMMM d, yyyy"));


            // var timeSpan = new TimeSpan(1,2,3);
            // System.Console.WriteLine(timeSpan);
            var today = DateTime.Now;
            string date =today.ToString("MM/d/yy");
            
            System.Console.WriteLine(date);

           
            









        }
    }
}
