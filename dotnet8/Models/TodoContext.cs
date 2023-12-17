using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models;

public class TodoContext : IdentityDbContext<IdentityUser>
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }
    public DbSet<TodoItem> TodoItems { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

}