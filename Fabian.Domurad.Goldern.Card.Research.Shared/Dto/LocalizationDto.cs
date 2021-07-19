using System.Collections.Generic;

namespace Fabian.Domurad.Golden.Card.Research.Shared.Dto
{
    public class LocalizationDto : BaseDto
    {
        public string Name { get; set; }

        public IEnumerable<FloorDto> Floors { get; set; } = new HashSet<FloorDto>();
    }
}
