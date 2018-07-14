using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace TheWall.Models
{

    public class Comment
    {
        [Key]
        public int Id {get;set;}
        [Required]
        [MinLength(8),MaxLength(255)]
        public string Content {get;set;}

        public User Creator {get; set;}
        public int UserId {get;set;}
        public int MessageId {get;set;}

        public Message BelongsTo {get; set;}
        public DateTime Created_At {get; set;}
        public DateTime Updated_At { get; set; }

        public Comment()
        {
            Created_At = DateTime.Now;
        }
    }
}