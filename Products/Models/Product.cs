using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Products.Models
{

    public class Product
    {
        
        public int Id { get; set; }

        public string Product_Name {get; set;}
        public string Description {get; set;}
        
        [NotMapped]
        public List<Category> Categories {get; set;}
        public DateTime Created_At { get; set; } = DateTime.Now;
        public DateTime Updated_At { get; set; } = DateTime.Now;
        public decimal Price { get; set; }
        
        
        public Product(){
            Categories = new List<Category>();
            
            
            
        }
        

        
    }
}