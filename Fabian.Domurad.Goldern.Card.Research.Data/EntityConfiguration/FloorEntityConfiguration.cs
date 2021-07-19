using Fabian.Domurad.Golden.Card.Research.Shared.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fabian.Domurad.Golden.Card.Research.Data.EntityConfiguration
{
    public class FloorEntityConfiguration : BaseEntityConfiguration<FloorEntity>
    {
        public override void Configure(EntityTypeBuilder<FloorEntity> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Number)
                .IsRequired();

            builder.HasOne(x => x.Localization)
                .WithMany(x => x.Floors)
                .HasForeignKey(x => x.LocalizationId);
        }
    }
}
