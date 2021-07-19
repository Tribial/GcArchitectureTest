using Fabian.Domurad.Golden.Card.Research.Shared.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Fabian.Domurad.Golden.Card.Research.Data.EntityConfiguration
{
    public class UserEntityConfiguration : BaseEntityConfiguration<UserEntity>
    {
        public override void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Username)
                .IsRequired()
                .HasMaxLength(128);
            builder.HasIndex(x => x.Username)
                .IsUnique();

            builder.Property(x => x.Firstname)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(x => x.Lastname)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(128);
            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.Property(x => x.PasswordHash)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(x => x.Role)
                .IsRequired();
        }
    }
}
