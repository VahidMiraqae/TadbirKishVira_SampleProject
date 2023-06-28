using Microsoft.EntityFrameworkCore;
using SampleProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) 
        {
            
        }

        public DbSet<Request> Requests { get; set; }
        public DbSet<CoverageType> CoverageTypes { get; set; } 
        public DbSet<RequestCoverage> RequestCoverages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequestCoverage>(entity =>
            {
                entity.HasOne<Request>(aa => aa.Request)
                .WithMany(aa => aa.Coverages)
                .HasForeignKey(aa => aa.RequestId);
            });
                

            modelBuilder.Entity<CoverageType>().HasData(new[]
            {
                new CoverageType()
                {
                    Id = 1,
                    Title = "Surgical",
                    PersianTitle = "جراحی",
                    MinCapital = 5000,
                    MaxCapital = 500_000_000,
                    Rate = 0.0052
                },
                new CoverageType()
                {
                    Id = 2,
                    Title = "Dental",
                    PersianTitle = "دندانپزشکی",
                    MinCapital = 4000,
                    MaxCapital = 400_000_000,
                    Rate = 0.0042
                },
                new CoverageType()
                {
                    Id = 3,
                    Title = "Hospital",
                    PersianTitle = "بستری",
                    MinCapital = 2000,
                    MaxCapital = 200_000_000,
                    Rate = 0.005
                },
            });
        }


    }
}
