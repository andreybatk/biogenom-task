using BioGenom.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace BioGenom.DB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Report> Reports { get; set; }
        public DbSet<DailyIntake> DailyIntakes { get; set; }
        public DbSet<NewDailyIntake> NewDailyIntakes { get; set; }
        public DbSet<PersonalizedSet> PersonalizedSets { get; set; }
        public DbSet<PersonalizedItem> PersonalizedItems { get; set; }
        public DbSet<Product> Products { get; set; }

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

            modelBuilder.Entity<Report>()
                .HasOne(r => r.PersonalizedSet)
                .WithOne(p => p.Report)
                .HasForeignKey<PersonalizedSet>(p => p.ReportId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PersonalizedSet>()
                .HasMany(s => s.Items)
                .WithOne(i => i.PersonalizedSet)
                .HasForeignKey(i => i.PersonalizedSetId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PersonalizedItem>()
                .HasOne(pi => pi.Product)
                .WithMany()
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}