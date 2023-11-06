using Microsoft.EntityFrameworkCore;
using Student.Web.Api.Models;

namespace Student.Web.Api.Data
{
    public class StudentDataContext: DbContext
    {
        protected readonly IConfiguration _config; 

        public DbSet<Pupil> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Grading> Grading { get; set; }
        public DbSet<Grade> Grades { get; set; }


        public StudentDataContext(
            DbContextOptions<StudentDataContext> options, 
            IConfiguration configuration) : base(options)
        {
            _config = configuration;
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_config
                .GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pupil>(p =>
            {
                p.ToTable("Pupils");
                p.HasKey(x => x.StudentId);
            });

            modelBuilder.Entity<Grading>(p =>
            {
                p.ToTable("Gradings");
                p.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Subject>(p =>
            {
                p.ToTable("Subjects");
                p.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Grade>(p =>
            {
                p.ToTable("Grades");
                p.HasKey(x => x.Id);
                p.HasOne(x => x.Pupil)
                    .WithMany(x => x.Grades)
                    .HasForeignKey(x => x.PupilId)
                    .OnDelete(DeleteBehavior.Cascade);
                p.HasOne(x => x.Subject)
                    .WithMany(x => x.Grades)
                    .HasForeignKey(x => x.SubjectId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}