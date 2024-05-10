using BlogCw.Areas.Identity.Data;
using BlogCw.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogCw.Data;

public class BlogCwContext : IdentityDbContext<User>
{
    public BlogCwContext(DbContextOptions<BlogCwContext> options)
        : base(options)
    {
    }
    
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Reaction> Reactions { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
