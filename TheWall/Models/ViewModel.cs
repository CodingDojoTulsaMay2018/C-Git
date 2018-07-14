using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace TheWall.Models
{

    public class ViewModel
    {
        public Message Messages {get; set;}
        public User Users {get; set;}
        public Comment Comments {get; set;}
    }



}