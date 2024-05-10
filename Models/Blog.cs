using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BlogCw.Areas.Identity.Data;

namespace BlogCw.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Title { get; set; }

        [Column(TypeName = "text")]
        public string Body { get; set; }
        
        [NotMapped] // This property will not be mapped to the database
        public IFormFile FeaturedImage { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string FeaturedImagePath { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DateCreated { get; set; }
        
        public ICollection<Reaction> Reactions { get; set; }
        public ICollection<Comment> Comments { get; set; }
        
        [Column("UserId")]
        public string UserId { get; set; }
        public User User { get; set; }
        
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
    }
}