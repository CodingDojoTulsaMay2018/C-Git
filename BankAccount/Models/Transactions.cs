using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace BankAccount.Models
{

    public class Transaction 
    {
        
        public int Id { get; set; }

        public double Amount {get; set;}
        // [ForeignKey("Users_user_id")]
        public int UserId { get; set; }
        public User User { get; set; }
        
        
        public DateTime Created_At { get; set; }
        
        
        

        
    }
}