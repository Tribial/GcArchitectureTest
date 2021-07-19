using System;
using System.Collections.Generic;

namespace Fabian.Domurad.Golden.Card.Research.Shared.Model
{
    public class FloorEntity : BaseEntity
    {
        public int Number { get; set; }

        public Guid LocalizationId { get; set; }
        public virtual LocalizationEntity Localization { get; set; }

        public virtual IEnumerable<DeskEntity> Desks { get; set; }
    }
}
