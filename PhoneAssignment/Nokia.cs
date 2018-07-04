using System;

namespace PhoneAssignment{
    public class Nokia : Phone, IRingable{

        public Nokia(string versionNumber, int batteryPercentage, string carrier, string ringTone) 
                : base(versionNumber, batteryPercentage, carrier, ringTone){
                    _versionNumber = versionNumber;
                    _batteryPercentage = batteryPercentage;
                    _carrier = carrier;  
                    _ringTone = ringTone;  
                            

                } 
                
                public string Ring() 
                {
                    return(_ringTone);
                }
                public string Unlock() 
                {
                    var unlock = "unlocked with fingerprint scanner";
                    return(unlock);
                }
                public override void DisplayInfo() 
                {
                    System.Console.WriteLine("Nokia " + _versionNumber+ " Battery percentage: " +_batteryPercentage+ "/n Carrier:" +_carrier );
                    
                }


    }



}