using System;

namespace ScorchApiV2.Static
{
    public static class DateTimeExtensions
    {
        public static int ToUnixTimestamp(this DateTime time)
        {
            return (Int32)time.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }

        public static DateTime FromUnixTimestamp(int timestamp)
        {
            var baseTime = new DateTime(1970,1 ,1);
            return baseTime.AddSeconds(timestamp);
        }
    }
}
