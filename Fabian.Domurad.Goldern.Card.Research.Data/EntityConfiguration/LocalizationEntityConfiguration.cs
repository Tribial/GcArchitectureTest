using Fabian.Domurad.Golden.Card.Research.Shared.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fabian.Domurad.Golden.Card.Research.Data.EntityConfiguration
{
    public class LocalizationEntityConfiguration : BaseEntityConfiguration<LocalizationEntity>
    {
        public override void Configure(EntityTypeBuilder<LocalizationEntity> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(128);
        }
    }
}
