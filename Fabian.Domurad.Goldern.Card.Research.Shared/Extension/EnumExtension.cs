using Fabian.Domurad.Golden.Card.Research.Shared.Constant;
using Fabian.Domurad.Golden.Card.Research.Shared.Enum;
using System;

namespace Fabian.Domurad.Golden.Card.Research.Shared.Extension
{
    public static class EnumExtension
    {
        public static string GetRoleName(this UserRole userRole)
        {
            return userRole switch
            {
                UserRole.Unknown => AuthConst.UnknownRole,
                UserRole.User => AuthConst.UserRole,
                UserRole.Moderator => AuthConst.ModeratorRole,
                UserRole.Administrator => AuthConst.AdministratorRole,
                _ => throw new ArgumentOutOfRangeException(nameof(userRole), userRole, null),
            };
        }
    }
}
