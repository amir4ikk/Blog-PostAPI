using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Date.DbContex;
public class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Likes> Likes { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<User>()
            .HasIndex(email => email.Email)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasData(new User()
            {
                Id = 1,
                Name = "Amirxon",   
                Email = "xumorahacker@gmail.com",
                Password = "123456",
                Phone_Number = "+998908376695",
                Role = Roles.SuperAdmin
            });

        modelBuilder.Entity<Post>()
                    .HasMany(i => i.Comments)
                    .WithOne(i => i.Post)
                    .HasForeignKey(i => i.Post_id)
                    .OnDelete(DeleteBehavior.ClientCascade);

        base.OnModelCreating(modelBuilder);
    }
}
