using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Products.Models
{

    public class Category
    {
        
        public int Id { get; set; }

        public string Category_Name {get; set;}
           
        
        public DateTime Created_At { get; set; } = DateTime.Now;
        public DateTime Updated_At { get; set; } = DateTime.Now;
        
        [NotMapped]
        public List<Product> Products {get; set;}
        public Category(){
            Products = new List<Product>();
            
            
            
        }
        

        
    }
}