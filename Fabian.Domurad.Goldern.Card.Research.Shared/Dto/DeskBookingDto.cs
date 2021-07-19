using System;

namespace Fabian.Domurad.Golden.Card.Research.Shared.Dto
{
    public class DeskBookingDto : BaseDto
    {
        public DateTime BookDate { get; set; }

        public Guid UserId { get; set; }
        public virtual UserDto User { get; set; }

        public Guid DeskId { get; set; }
        public virtual DeskDto Desk { get; set; }
    }
}
