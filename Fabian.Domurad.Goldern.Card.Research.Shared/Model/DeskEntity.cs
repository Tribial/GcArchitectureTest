using System;
using System.Collections.Generic;
using Fabian.Domurad.Golden.Card.Research.Shared.Enum;

namespace Fabian.Domurad.Golden.Card.Research.Shared.Model
{
    public class DeskEntity : BaseEntity
    {
        public int DeskNumber { get; set; }
        public int RoomNumber { get; set; }
        public bool IsLifted { get; set; }
        public bool IsUnavailable { get; set; }
        public DeskLocation Location { get; set; }
        public string Tribe { get; set; }

        public Guid? OwnerId { get; set; }
        public virtual UserEntity Owner { get; set; }

        public Guid FloorId { get; set; }
        public virtual FloorEntity Floor { get; set; }

        public virtual IEnumerable<DeskBookingEntity> DeskBookings { get; set; }
    }
}
