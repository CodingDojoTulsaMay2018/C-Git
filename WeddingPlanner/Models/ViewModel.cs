using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{

    public class ViewModel
    {
        public Wedding Weddings {get; set;}
        public User Users {get; set;}
        public Guest Guests {get; set;}

       
    }
    



}