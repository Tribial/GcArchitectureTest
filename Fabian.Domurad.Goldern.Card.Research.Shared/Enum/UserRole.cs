using System;
using System.ComponentModel;
using Fabian.Domurad.Golden.Card.Research.Shared.Constant;

namespace Fabian.Domurad.Golden.Card.Research.Shared.Enum
{
    [Flags]
    public enum UserRole
    {
        [Description(AuthConst.UnknownRole)]
        Unknown = 0,
        [Description(AuthConst.UserRole)]
        User = 1,
        [Description(AuthConst.ModeratorRole)]
        Moderator = 2,
        [Description(AuthConst.AdministratorRole)]
        Administrator = 3,
    }
}
