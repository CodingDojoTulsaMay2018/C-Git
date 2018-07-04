using System;

namespace PhoneAssignment{
    public class Galaxy : Phone, IRingable{

        public Galaxy(string versionNumber, int batteryPercentage, string carrier, string ringTone) 
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
                    return("unlocked with passcode");
                }
                public override void DisplayInfo() 
                {
                    System.Console.WriteLine("Galaxy " + _versionNumber+ " Battery percentage: " +_batteryPercentage+ " Carrier:" +_carrier);
                    // return("Nokia " + versionNumber+ "/n Battery percentage: " +batteryPercentage+ "/n Carrier:" +carrier)          
                }


    }



}