using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;


namespace LostInWoods.Models
{
    public abstract class BaseEntity {}
    public class Trails: BaseEntity
    {
        [Key]
        public long Id { get; set; }
 
        [Required(ErrorMessage = "Please enter between 5 and 140 characters")]
        [MinLength(5),MaxLength(140)]
        public string Trail_Name { get; set; }
 
        [Required]
        [MinLength(10),MaxLength(140)]
        public string Description {get;set;}

        [Required]       
        public double Trail_Length {get;set;}

        [Required]       
        public double Latitude {get;set;}

        [Required]       
        public double Longitude {get;set;}

        [Required]       
        public int Elevation_Change {get;set;}
    }
}

 
        
    