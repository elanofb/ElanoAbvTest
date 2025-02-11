namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Log
    {
        public int Id { get; set; }
        public string Event { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
    }
}
