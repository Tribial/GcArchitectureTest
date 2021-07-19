using System.ComponentModel.DataAnnotations;
using Fabian.Domurad.Golden.Card.Research.Shared.Constant;

namespace Fabian.Domurad.Golden.Card.Research.Shared.BindingModel
{
    public class UserAuthenticateBindingModel
    {
        [Required(ErrorMessage = BindingModelErrorConst.UserUsernameRequired)]
        public string Username { get; set; }
        [Required(ErrorMessage = BindingModelErrorConst.UserPasswordRequired)]
        public string Password { get; set; }
    }
}
