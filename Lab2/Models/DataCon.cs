using Microsoft.EntityFrameworkCore;

namespace Lab2.Models
{
    public class DataCon : DbContext
    {
        public DataCon() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=localhost;Database=MVCLab2;Trusted_Connection=True;TrustServerCertificate=True");
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<crsResult> crsResults{ get; set; }

        protected override void OnModelCreating(ModelBuilder op)
        {
            base.OnModelCreating(op);

            op.Entity<crsResult>(o =>
            {
                o.HasKey(o => o.ID);
                o.HasOne(o => o.trainee)
                .WithMany(o => o.crsResults)
                .HasForeignKey(o => o.Trainee_ID)
                .OnDelete(DeleteBehavior.NoAction);

                o.HasOne(o => o.course)
                .WithMany(o => o.crsResults)
                .HasForeignKey(o => o.Course_ID)
                .OnDelete(DeleteBehavior.NoAction);
            });

            op.Entity<Course>(o =>
            {
                o.HasKey(o => o.Course_ID);
                o.HasOne(o => o.Department)
                .WithMany(o => o.Courses)
                .HasForeignKey(o => o.Dep_ID)
                .OnDelete(DeleteBehavior.NoAction);
            });

            op.Entity<Trainee>(o =>
            {
                o.HasKey(o => o.Trainee_Id);
                o.HasOne(o => o.Department)
                .WithMany(o => o.Trainees)
                .HasForeignKey(o => o.Dep_ID)
                .OnDelete(DeleteBehavior.NoAction);
            });

            op.Entity<Instructor>(o =>
            {
                o.HasKey(o => o.Inst_Id);
                o.HasOne(o => o.Department)
                .WithMany(o => o.Instructors)
                .HasForeignKey(o => o.Dep_ID)
                .OnDelete(DeleteBehavior.NoAction);

                o.HasOne(o => o.Course)
                .WithMany(o => o.instructors)
                .HasForeignKey(o => o.Course_id)
                .OnDelete(DeleteBehavior.NoAction);
            });

            op.Entity<Department>(o =>{
                o.HasKey(o => o.Department_ID);
            });

        }
    }
}
