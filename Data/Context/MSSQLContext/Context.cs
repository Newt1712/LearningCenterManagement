using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Data.Context.MSSQLContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Parent> Parents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .ConfigureWarnings(w =>
                w.Ignore(SqlServerEventId.SavepointsDisabledBecauseOfMARS));
        optionsBuilder.UseSqlServer(AppSettings.MSSQLSettings.SQLConn);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Parent>(entity => { entity.ToTable("parent"); });
    }
}