using System;
using System.ComponentModel.DataAnnotations;
using Fabian.Domurad.Golden.Card.Research.Shared.Constant;

namespace Fabian.Domurad.Golden.Card.Research.Shared.BindingModel
{
    public class FloorAddBindingModel
    {
        [Required(ErrorMessage = BindingModelErrorConst.FloorNumberRequired)]
        public int Number { get; set; }
        [Required(ErrorMessage = BindingModelErrorConst.FloorLocIdRequired)]
        public Guid LocalizationId { get; set; }
    }
}
