namespace SalaryAdvance.Domain.Events
{
    public class SalaryAdvanceRequested : DomainEvent
    {
        public Guid RequestId { get; }
        public int EmployeeId { get; }
        public double Amount { get; }
        public string Reason { get; }

        public SalaryAdvanceRequested(Guid requestId, int employeeId, double amount, string reason)
        {
            RequestId = requestId;
            EmployeeId = employeeId;
            Amount = amount;
            Reason = reason;
        }
    }

    public class SalaryAdvanceApproved : DomainEvent
    {
        public Guid RequestId { get; }
        public DateTime ApprovedAt { get; }

        public SalaryAdvanceApproved(Guid requestId, DateTime approvedAt)
        {
            RequestId = requestId;
            ApprovedAt = approvedAt;
        }
    }

    public class SalaryAdvanceRejected : DomainEvent
    {
        public Guid RequestId { get; }
        public string RejectionReason { get; }

        public SalaryAdvanceRejected(Guid requestId, string rejectionReason)
        {
            RequestId = requestId;
            RejectionReason = rejectionReason;
        }
    }
}
