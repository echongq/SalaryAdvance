namespace SalaryAdvance.Domain.Entities
{
    public class SalaryAdvanceRequest
    {
        public Guid RequestId { get; set; }
        public int EmployeeId { get; set; }
        public double Amount { get; set; }
        public string Reason { get; set; } = string.Empty;
        public SalaryAdvanceStatus Status { get; set; } = SalaryAdvanceStatus.Pending;
    }
}
