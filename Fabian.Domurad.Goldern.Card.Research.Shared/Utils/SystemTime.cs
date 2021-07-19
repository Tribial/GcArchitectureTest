using System;

namespace Fabian.Domurad.Golden.Card.Research.Shared.Utils
{
    public static class SystemTime
    {
        private static DateTime? _utcDateTime;

        public static DateTime UtcNow => _utcDateTime ?? DateTime.UtcNow;

        public static void SetUtc(DateTime utc)
        {
            _utcDateTime = utc;
        }

        public static void ResetUtc()
        {
            _utcDateTime = null;
        }
    }
}
