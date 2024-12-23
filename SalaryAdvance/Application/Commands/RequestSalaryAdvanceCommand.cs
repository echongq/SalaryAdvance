using MediatR;
using SalaryAdvance.Application.Interfaces;
using SalaryAdvance.Domain.Entities;
using SalaryAdvance.Domain.Events;
using SalaryAdvance.Infrastructure;

namespace SalaryAdvance.Application.Commands
{
    public record RequestSalaryAdvanceCommand(SalaryAdvanceRequest sar) : IRequest<Response>;
    //{
    //    public int EmployeeId { get; set; }
    //    public decimal RequestedAmount { get; set; }
    //    public string Reason { get; set; } = string.Empty;
    //}

    public class Handler : IRequestHandler<RequestSalaryAdvanceCommand, Response>
    {
        private readonly DBContext _context;
        private readonly IEventPublisher _eventPublisher;

        public Handler(DBContext context, IEventPublisher eventPublisher)
        {
            _context = context;
            _eventPublisher = eventPublisher;
        }

        public async Task<Response> Handle(RequestSalaryAdvanceCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.sar.EmployeeId);
            if (employee == null) throw new Exception("Employee not found.");
            if (request.sar.Amount > employee.Salary * 0.5)
                throw new Exception("Requested amount exceeds 50% of salary.");

            var salaryAdvanceRequest = new SalaryAdvanceRequest
            {
                RequestId = Guid.NewGuid(),
                EmployeeId = request.sar.EmployeeId,
                Amount = request.sar.Amount,
                Reason = request.sar.Reason
            };

            _context.SalaryAdvanceRequests.Add(salaryAdvanceRequest);
            await _context.SaveChangesAsync();
            var domainEvent = new SalaryAdvanceRequested(
            salaryAdvanceRequest.RequestId,
            salaryAdvanceRequest.EmployeeId,
            salaryAdvanceRequest.Amount,
            salaryAdvanceRequest.Reason
        );

            await _eventPublisher.PublishAsync(domainEvent, cancellationToken);


            return new Response(salaryAdvanceRequest);
        }
    }
    public record Response(SalaryAdvanceRequest sar) { }
}
