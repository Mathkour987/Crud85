using Crud7.Models;
using Microsoft.EntityFrameworkCore;
using Crud7.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Crud> Crud { get; set; }
}
