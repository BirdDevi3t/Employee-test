using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employee { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Map entity to existing table
        modelBuilder.Entity<Employee>().ToTable("employee");
        
        
        modelBuilder.Entity<Employee>()
            .Property(e => e.id).HasColumnName("id");
        
        
    }
}

