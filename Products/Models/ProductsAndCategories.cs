using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Products.Models
{

    public class ProductsAndCategories
    {
               
        public Product Product {get;set;}
        public int productId {get;set;}
        public int categoryId {get;set;}
        public Category Category {get;set;}
                 
            
        }
 
        
    }
