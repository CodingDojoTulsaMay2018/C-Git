using System.Collections.Generic;
using System;
namespace RpgGame{

    public class Wizard : Human{

            public Wizard(string nameVal="", int intVal = 25, int healthVal =50) : base(){
            name = nameVal;        
            intelligence = intVal;       
            health = healthVal;
            }

            public void heal(){
                intelligence += 10;
            }
            public void fireball(object obj){
            Random rand = new Random();
            Human enemy = obj as Human;
            var fireballDamage = rand.Next(20,51);
            System.Console.WriteLine(name + " hit " + enemy.name + " for " + fireballDamage + " fireball damage! BOOM!" );
            enemy.health -= fireballDamage;            
            
            }

        }




        
    }

