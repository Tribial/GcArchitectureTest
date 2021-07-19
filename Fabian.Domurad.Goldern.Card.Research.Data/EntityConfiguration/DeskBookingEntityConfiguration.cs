using Fabian.Domurad.Golden.Card.Research.Shared.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fabian.Domurad.Golden.Card.Research.Data.EntityConfiguration
{
    public class DeskBookingEntityConfiguration : BaseEntityConfiguration<DeskBookingEntity>
    {
        public override void Configure(EntityTypeBuilder<DeskBookingEntity> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.BookDate)
                .IsRequired();
            builder.HasIndex(x => x.BookDate);

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Desk)
                .WithMany(x => x.DeskBookings)
                .HasForeignKey(x => x.DeskId);
        }
    }
}
