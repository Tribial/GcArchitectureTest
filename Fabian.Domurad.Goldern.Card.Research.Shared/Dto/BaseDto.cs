using System;

namespace Fabian.Domurad.Golden.Card.Research.Shared.Dto
{
    public abstract class BaseDto : Dto
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
