using Fabian.Domurad.Golden.Card.Research.Shared.Enum;
using System;
using System.Collections.Generic;

namespace Fabian.Domurad.Golden.Card.Research.Shared.Dto
{
    public class DeskDto : BaseDto
    {
        public int DeskNumber { get; set; }
        public int RoomNumber { get; set; }
        public bool IsLifted { get; set; }
        public bool IsUnavailable { get; set; }
        public DeskLocation Location { get; set; }
        public string Tribe { get; set; }

        public Guid? OwnerId { get; set; }
        public UserDto Owner { get; set; }

        public Guid FloorId { get; set; }
        public FloorDto Floor { get; set; }

        public IEnumerable<DeskBookingDto> DeskBookings { get; set; }

        public string DeskName => $"{Floor.Number}.{RoomNumber}.{DeskNumber}";
    }
}
