using Fabian.Domurad.Golden.Card.Research.Data.EntityConfiguration;
using Fabian.Domurad.Golden.Card.Research.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace Fabian.Domurad.Golden.Card.Research.Data
{
    public class GcResearchDbContext : DbContext
    {
        public GcResearchDbContext(DbContextOptions<GcResearchDbContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> User { get; set; }
        public DbSet<LocalizationEntity> Localization { get; set; }
        public DbSet<FloorEntity> Floor { get; set; }
        public DbSet<DeskEntity> Desk { get; set; }
        public DbSet<DeskBookingEntity> DeskBooking { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LocalizationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new FloorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DeskEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DeskBookingEntityConfiguration());
        }
    }
}
