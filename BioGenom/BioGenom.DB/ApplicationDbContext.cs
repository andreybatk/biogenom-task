using BioGenom.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace BioGenom.DB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { Database.EnsureCreated(); }

        public DbSet<Report> Reports { get; set; }
        public DbSet<DailyIntake> DailyIntakes { get; set; }
        public DbSet<NewDailyIntake> NewDailyIntakes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Report>()
                .HasMany(r => r.DailyIntakes)
                .WithOne(d => d.Report)
                .HasForeignKey(d => d.ReportId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Report>()
                .HasMany(r => r.NewDailyIntakes)
                .WithOne(d => d.Report)
                .HasForeignKey(d => d.ReportId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}