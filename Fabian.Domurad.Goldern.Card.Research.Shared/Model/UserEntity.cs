using Fabian.Domurad.Golden.Card.Research.Shared.Enum;
using System;

namespace Fabian.Domurad.Golden.Card.Research.Shared.Model
{
    public class UserEntity : BaseEntity
    {
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; }
    }
}
