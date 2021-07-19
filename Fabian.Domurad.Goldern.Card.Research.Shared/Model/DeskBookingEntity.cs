using System;

namespace Fabian.Domurad.Golden.Card.Research.Shared.Model
{
    public class DeskBookingEntity : BaseEntity
    {
        public DateTime BookDate { get; set; }

        public Guid UserId { get; set; }
        public virtual UserEntity User { get; set; }

        public Guid DeskId { get; set; }
        public virtual DeskEntity Desk { get; set; }
    }
}
