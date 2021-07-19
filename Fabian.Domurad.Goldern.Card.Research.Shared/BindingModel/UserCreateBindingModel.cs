using System.ComponentModel.DataAnnotations;
using Fabian.Domurad.Golden.Card.Research.Shared.Constant;

namespace Fabian.Domurad.Golden.Card.Research.Shared.BindingModel
{
    public class UserCreateBindingModel
    {
        [Required(ErrorMessage = BindingModelErrorConst.UserUsernameRequired)]
        [MinLength(3, ErrorMessage = BindingModelErrorConst.UserUsernameMinLength)]
        [MaxLength(128, ErrorMessage = BindingModelErrorConst.UserUsernameMaxLength)]
        public string Username { get; set; }

        [Required(ErrorMessage = BindingModelErrorConst.UserFirstNameRequired)]
        [MinLength(3, ErrorMessage = BindingModelErrorConst.UserFirstNameMinLength)]
        [MaxLength(128, ErrorMessage = BindingModelErrorConst.UserFirstNameMaxLength)]
        public string Firstname { get; set; }

        [Required(ErrorMessage = BindingModelErrorConst.UserLastNameRequired)]
        [MinLength(3, ErrorMessage = BindingModelErrorConst.UserLastNameMinLength)]
        [MaxLength(128, ErrorMessage = BindingModelErrorConst.UserLastNameMaxLength)]
        public string Lastname { get; set; }

        [Required(ErrorMessage = BindingModelErrorConst.UserEmailRequired)]
        [MinLength(3, ErrorMessage = BindingModelErrorConst.UserEmailMinLength)]
        [MaxLength(128, ErrorMessage = BindingModelErrorConst.UserEmailMaxLength)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = BindingModelErrorConst.UserPasswordRequired)]
        [MinLength(5, ErrorMessage = BindingModelErrorConst.UserPasswordMinLength)]
        [MaxLength(30, ErrorMessage = BindingModelErrorConst.UserPasswordMaxLength)]
        public string Password { get; set; }
    }
}
