namespace Human{


    public class Human{

        public string name;
        public int strength = 3;
        public int intelligence = 3;
        public int dexterity = 3;
        public int health = 100;

        public Human(string firstname,int stren, int intel, int dext, int hp){
            name = firstname;
            strength = stren;
            intelligence = intel;
            dexterity = dext;
            health = hp;
        }
        public void Attack(Human attacked,int damage){
            // System.Console.WriteLine(attacked);
            
            if(attacked is Human){
                attacked.health -= damage*5;
            }
            else{
                System.Console.WriteLine("This is not a human");
            }
            


        }


    }

}