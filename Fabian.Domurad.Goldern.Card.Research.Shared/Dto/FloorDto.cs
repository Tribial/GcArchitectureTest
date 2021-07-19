using System;
using System.Collections.Generic;

namespace Fabian.Domurad.Golden.Card.Research.Shared.Dto
{
    public class FloorDto : BaseDto
    {
        public int Number { get; set; }

        public Guid LocalizationId { get; set; }
        public virtual LocalizationDto Localization { get; set; }

        public virtual IEnumerable<DeskDto> Desks { get; set; } = new HashSet<DeskDto>();
    }
}
