using System;
using System.Collections.Generic;
using System.Text;
using Fabian.Domurad.Golden.Card.Research.Shared.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fabian.Domurad.Golden.Card.Research.Data.EntityConfiguration
{
    public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.ModifiedAt)
                .IsRequired(false);

            builder.Property(x => x.RemovedAt)
                .IsRequired(false);
        }
    }
}
