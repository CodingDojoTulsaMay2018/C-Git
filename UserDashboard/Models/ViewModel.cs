using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace UserDashboard.Models
{

    public class ViewModel
    {
        public Message Messages {get; set;}
        public LoginCheck loginUser {get; set;}
        public Comment Comments {get; set;}

        public User regUser {get; set;}

        public EditUser editUser {get;set;}
        

        public EditPassword editPassword {get;set;}

       
    }
    



}