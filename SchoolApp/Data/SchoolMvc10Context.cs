using Microsoft.EntityFrameworkCore;
using SchoolApp.Models;

namespace SchoolApp.Data;

public class SchoolMvc10Context : DbContext
{
    public SchoolMvc10Context(DbContextOptions<SchoolMvc10Context> options) : base(options) 
    { }

    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Capability> Capabilities { get; set; }
    public DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Teacher>(entity =>
        {

            entity.Property(e => e.Institution).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);

            entity.HasOne(t => t.User)
                .WithOne(p => p.Teacher)
                .HasForeignKey<Teacher>(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Teachers_Users_UserId");

            entity.HasIndex(e => e.Institution, "IX_Teachers_Institution");
            entity.HasIndex(e => e.UserId, "UQ_Teachers_UserId").IsUnique();
        });
    }


}
