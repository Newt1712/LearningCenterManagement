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

    public virtual DbSet<Attendances> Attendances { get; set; }
    public virtual DbSet<Classrooms> Classrooms { get; set; }
    public virtual DbSet<Parents> Parents { get; set; }
    public virtual DbSet<Schedules> Schedules { get; set; }
    public virtual DbSet<Teachers> Teachers { get; set; }
    public virtual DbSet<Students> Students { get; set; }
    public virtual DbSet<Students_Subject> StudentsSubjects { get; set; }
    public virtual DbSet<Students_Classrooms> StudentsClassrooms { get; set; }
    public virtual DbSet<Users> Users { get; set; }
    public virtual DbSet<Subjects> Subjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .ConfigureWarnings(w =>
                w.Ignore(SqlServerEventId.SavepointsDisabledBecauseOfMARS));
        optionsBuilder.UseSqlServer(AppSettings.MSSQLSettings.SQLConn);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendances>(entity => { entity.ToTable("attendances"); });
        modelBuilder.Entity<Classrooms>(entity => { entity.ToTable("classrooms"); });
        modelBuilder.Entity<Parents>(entity => { entity.ToTable("parents"); });
        modelBuilder.Entity<Schedules>(entity => { entity.ToTable("schedules"); });
        modelBuilder.Entity<Teachers>(entity => { entity.ToTable("teachers"); });
        modelBuilder.Entity<Students>(entity => { entity.ToTable("students"); });
        modelBuilder.Entity<Students_Subject>(entity => { entity.ToTable("students_subject"); });
        modelBuilder.Entity<Students_Classrooms>(entity => { entity.ToTable("students_classrooms"); });
        modelBuilder.Entity<Users>(entity => { entity.ToTable("users"); });
        modelBuilder.Entity<Subjects>(entity => { entity.ToTable("subjects"); });
    }
}