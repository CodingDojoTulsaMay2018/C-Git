using System.Collections.Generic;
using System;

namespace RpgGame{


    public class Ninja : Human{

                public Ninja(string nameVal="", int dexVal = 175) : base(){
                name = nameVal;        
                dexterity = dexVal;       
   
                }
                public void deathBlow(object obj){
                Human enemy = obj as Human;
                // var fireballDamage = rand.Next(20,51);
                System.Console.WriteLine(name + " stole 10 health from " + enemy.name );
                enemy.health -= 10; 
                health +=10;           
                
                }
                public void get_away(){
                health -= 15;
            }

    }


}