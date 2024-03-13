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
    public virtual DbSet<Teacher> Teachers { get; set; }
    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<Classroom> Classrooms { get; set; }
    public virtual DbSet<Attendance> Attendances { get; set; }
    public virtual DbSet<ClassRoom_Student> ClassRoomStudents { get; set; }
    public virtual DbSet<Grade> Grades { get; set; }
    public virtual DbSet<Slot> Slots { get; set; }
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
        modelBuilder.Entity<Teacher>(entity => { entity.ToTable("teacher"); });
        modelBuilder.Entity<Course>(entity => { entity.ToTable("course"); });
        modelBuilder.Entity<Student>(entity => { entity.ToTable("student"); });
        modelBuilder.Entity<Classroom>(entity => { entity.ToTable("classroom"); });
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(a => new { a.student_id, a.slot_id });
            entity.ToTable("attendance");
        });
        modelBuilder.Entity<ClassRoom_Student>(entity =>
        {
            entity.HasKey(a => new { a.student_id, a.classroom_id });
            entity.ToTable("classroom_student");
        });
        modelBuilder.Entity<Grade>(entity => { entity.ToTable("grade"); });

        modelBuilder.Entity<Slot>(entity => { entity.ToTable("Slots");  });
    }
}