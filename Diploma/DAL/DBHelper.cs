using Microsoft.EntityFrameworkCore;
using Diploma.DAL.Models;

namespace Diploma.DAL;

public class DBHelper : DbContext
{
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Teacher> Teachers { get; set; } = null!;
    public DbSet<TextSettings> TextSettings { get; set; } = null!;
    
    public DBHelper()
    {
        Database.EnsureCreated();
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=diplomadb;Username=postgres;Password=Vomber123");
    }

    
}