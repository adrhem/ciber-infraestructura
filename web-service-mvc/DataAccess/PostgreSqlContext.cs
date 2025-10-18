using Microsoft.EntityFrameworkCore;
using CiberInfraestructuraApi.Models;

namespace CiberInfraestructuraApi.DataAccess
{
  public class PostgreSqlContext : DbContext
  {
    public DbSet<CatPersonal> CatPersonal { get; set; }

    public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
    {
    }

    public override int SaveChanges()
    {
      ChangeTracker.DetectChanges();
      return base.SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }

  }
}