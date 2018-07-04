using System.Collections.Generic;
namespace RpgGame{

    public class Human{

        public string name { get; set; }
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }
        public int health { get; set; }

        public Human(string nameVal="",int strengthVal = 3,int intVal = 3, int dexVal =3 , int healthVal = 48){
            name = nameVal;
            strength = strengthVal;
            intelligence = intVal;
            dexterity = dexVal;
            health = healthVal;
        }

        public void attack(object obj){
            Human enemy = obj as Human;
            enemy.health -= strength*5;            
            
        }

    }
}