namespace FJU.Inventario.Domain.Entities
{
    public class AccessToken
    {
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public long Timestamp { get; }

        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public AccessToken()
        {
            Timestamp = ConvertToTimestamp(DateTime.UtcNow);
        }

        private static long ConvertToTimestamp(DateTime value)
        {
            TimeSpan elapsedTime = value - Epoch;
            return (long)elapsedTime.TotalSeconds;
        }
    }
}
