using System;

namespace Fabian.Domurad.Golden.Card.Research.Shared.Model
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? RemovedAt { get; set; }
    }
}
