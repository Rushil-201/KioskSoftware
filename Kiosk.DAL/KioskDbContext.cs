using Kiosk.DAL.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Kiosk.DAL
{
    /// <summary>
    /// DB Context for storing data in Database
    /// </summary>
    public partial class KioskDbContext: DbContext
    {
        /// <summary>
        /// DB Context Options
        /// </summary>
        /// <param name="contextOptions">DB Context Options</param>
        public KioskDbContext(DbContextOptions<KioskDbContext> contextOptions): base(contextOptions)
        {
            
        }
        
        public virtual DbSet<Concert> Concert { get; set; }

        public virtual DbSet<Reservation> Reservation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Concert>(entity => {
                entity.HasKey(e => e.Id);
                entity.ToTable(e => e.HasCheckConstraint("check_Availability_constraint", "[AvailableCapacity] >= 0"));
                entity.Property(e => e.AvailableCapacity).IsConcurrencyToken();
                
            });

            modelBuilder.Entity<Reservation>(entity => {
                entity.HasKey(e => e.Id);
            });

            // Seed Data

            modelBuilder.Entity<Concert>(entity =>
            {
                entity.HasData(new List<Concert> {
                    new Concert
                    {
                        Id = Guid.NewGuid(),
                        Name = "Taylor",
                        MaxCapacity = 5000,
                        AvailableCapacity = 5000,
                        IsAvailable = true,
                        PerformanceDateTime = DateTime.Now.AddDays(10),
                        Price = 100,
                    },
                    new Concert
                    {
                        Id = Guid.NewGuid(),
                        Name = "Eminem",
                        MaxCapacity = 1000,
                        AvailableCapacity = 1000,
                        IsAvailable = true,
                        PerformanceDateTime = DateTime.Now.AddDays(5),
                        Price = 70,
                    },
                    new Concert
                    {
                        Id = Guid.NewGuid(),
                        Name = "Ariande",
                        MaxCapacity = 500,
                        AvailableCapacity = 500,
                        IsAvailable = true,
                        PerformanceDateTime = DateTime.Now.AddDays(3),
                        Price = 50,
                    },
                    new Concert
                    {
                        Id = Guid.NewGuid(),
                        Name = "Arjit",
                        MaxCapacity = 500,
                        AvailableCapacity = 500,
                        IsAvailable = true,
                        PerformanceDateTime = DateTime.Now.AddDays(15),
                        Price = 80,
                    }

                }); 

            });
        }

        
    }

}