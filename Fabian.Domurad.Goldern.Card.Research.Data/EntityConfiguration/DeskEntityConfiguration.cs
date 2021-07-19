using Fabian.Domurad.Golden.Card.Research.Shared.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fabian.Domurad.Golden.Card.Research.Data.EntityConfiguration
{
    public class DeskEntityConfiguration : BaseEntityConfiguration<DeskEntity>
    {
        public override void Configure(EntityTypeBuilder<DeskEntity> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.DeskNumber)
                .IsRequired();

            builder.Property(x => x.RoomNumber)
                .IsRequired();

            builder.Property(x => x.IsLifted)
                .IsRequired();

            builder.Property(x => x.IsUnavailable)
                .IsRequired();

            builder.Property(x => x.Location)
                .IsRequired();

            builder.Property(x => x.Tribe)
                .IsRequired()
                .HasMaxLength(128);

            builder.HasOne(x => x.Owner)
                .WithMany()
                .HasForeignKey(x => x.OwnerId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder.HasOne(x => x.Floor)
                .WithMany(x => x.Desks)
                .HasForeignKey(x => x.FloorId);
        }
    }
}
