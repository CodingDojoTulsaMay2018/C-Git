using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace TheWall.Models
{

    public class Message
    {
        
        public int Id { get; set; }

        [Required]
        [MinLength(8),MaxLength(255)]
        public string Content {get; set;}
        
        public int UserId { get; set; } ///Column foreign key
        public User Creator { get; set; }
        
        public List<Comment> Comments {get; set;}
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        
        public Message(){
            List<Comment> Comments = new List<Comment>();
            Created_At =DateTime.Now;
        }
        

        
    }
}