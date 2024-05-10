using System.ComponentModel.DataAnnotations.Schema;
using BisleriumBlogProject.Models;
using BlogCw.Areas.Identity.Data;

namespace BlogCw.Models;

public class Reaction
{
    public int Id { get; set; }
    public ReactionType Type { get; set; }

    [Column("UserId")]
    public int UserId { get; set; }

    [Column("BlogId")]
    public int BlogId { get; set; }

    [Column("CommentId")]
    public int CommentId { get; set; }

    public User User { get; set; }
    public Blog Blog { get; set; }
    public Comment Comment { get; set; }
}