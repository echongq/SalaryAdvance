namespace SalaryAdvance.Domain.Entities
{
    public class EventLog
    {
        public int EventLogId { get; set; }
        public string? EventType { get; set; }
        public DateTime Timestamp { get; set; }
        public string? Data { get; set; }
    }
}
