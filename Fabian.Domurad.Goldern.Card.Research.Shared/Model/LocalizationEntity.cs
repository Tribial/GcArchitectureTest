using System;
using System.Collections.Generic;
using System.Text;

namespace Fabian.Domurad.Golden.Card.Research.Shared.Model
{
    public class LocalizationEntity : BaseEntity
    {
        public string Name { get; set; }

        public virtual IEnumerable<FloorEntity> Floors { get; set; }
    }
}
