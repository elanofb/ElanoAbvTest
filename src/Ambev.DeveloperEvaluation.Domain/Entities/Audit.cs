namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Audit
    {
        public int Id { get; set; }
        public string TableName { get; set; } = string.Empty;
        public string Operation { get; set; } = string.Empty; // e.g., Insert, Update, Delete
        public DateTime Timestamp { get; set; }
        public string PerformedBy { get; set; } = string.Empty; // User who performed the operation
        public string Details { get; set; } = string.Empty; // JSON or detailed description
    }
}
