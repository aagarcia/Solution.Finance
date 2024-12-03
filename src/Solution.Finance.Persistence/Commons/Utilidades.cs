namespace Solution.Finance.Persistence.Commons
{
    public static class Utilidades
    {
        static Utilidades()
        {

        }

        public static DateTime GetEcuadorTime()
        {
            DateTime utcDateTime = DateTime.UtcNow;
            TimeZoneInfo ecuadorTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, ecuadorTimeZone);
        }
    }
}
