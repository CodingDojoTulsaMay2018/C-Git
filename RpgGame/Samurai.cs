using System.Collections.Generic;
using System;
namespace RpgGame{

    public class Samurai : Human{
            public static int activeCount = 0;
            public static int starthealth = 200;
            public Samurai(string nameVal="",int healthVal =200) : base(){
            
            activeCount++;
            name = nameVal;            
            health = healthVal;
            
            }
                public void deathBlow(object obj){
                    Human enemy = obj as Human;
                    // var fireballDamage = rand.Next(20,51);
                    if(enemy.health < 50){
                        System.Console.WriteLine(enemy.name + " Took a...Death Blow!!!");
                        enemy.health = 0;
                    }
                    else{
                        System.Console.WriteLine("Not a death blow, MISS");
                    
                    }                         
                }
                public void meditate(){
                    health = starthealth;
                }


    }

}