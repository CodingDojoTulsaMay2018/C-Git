using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{

    public class Guest
    {
        [Key]
        public int Id {get;set;}
       
        public User InvitedGuest {get; set;}
        public Wedding Weddings {get;set;}
        public int UserId {get;set;}
        public int WeddingId {get;set;}


    }
}