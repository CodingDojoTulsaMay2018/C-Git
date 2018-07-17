using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DojoSecrets.Models
{

    public class ViewModel
    {
        public Secret Secrets {get; set;}
        public User Users {get; set;}
        public Like Likes {get; set;}

       
    }
    



}