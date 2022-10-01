using AvaliacaoD7.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoD7.DataContext;

public sealed class UserContext : DbContext
{
    private const string ConnectionString = "Data Source=products.db";
    public UserContext() { }

    public UserContext(DbContextOptions<UserContext> options) : base(options) { }

    [UsedImplicitly] public DbSet<User> Users { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>().HasKey(m => m.UserName);
        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(ConnectionString);
    }

    public void EnsureCreated() { Database.EnsureCreated(); }

    public void Recreate()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
}