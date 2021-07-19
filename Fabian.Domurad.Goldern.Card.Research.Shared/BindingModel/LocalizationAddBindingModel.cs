using System.ComponentModel.DataAnnotations;
using Fabian.Domurad.Golden.Card.Research.Shared.Constant;

namespace Fabian.Domurad.Golden.Card.Research.Shared.BindingModel
{
    public class LocalizationAddBindingModel
    {
        [Required(ErrorMessage = BindingModelErrorConst.LocNameRequired)]
        [MinLength(3, ErrorMessage = BindingModelErrorConst.LocNameMinLength)]
        [MaxLength(128, ErrorMessage = BindingModelErrorConst.LocNameMaxLength)]
        public string Name { get; set; }
    }
}
