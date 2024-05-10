using System;
using System.ComponentModel.DataAnnotations.Schema;
using BlogCw.Areas.Identity.Data;

namespace BlogCw.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Column(TypeName = "text")]
        public string Content { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DateCreated { get; set; }
        
        [Column("UserId")]
        public int UserId { get; set; }

        [Column("BlogId")]
        public int BlogId { get; set; }

        public User User { get; set; }
        public Blog Blog { get; set; }
        
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
    }
}