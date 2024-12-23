using MediatR;
using SalaryAdvance.Domain.Entities;
using SalaryAdvance.Infrastructure;

namespace SalaryAdvance.Application.Commands
{
    public class RejectRequestSalaryAdvanceCommand
    {
        public record Command(SalaryAdvanceRequest sar) : IRequest<Response> { }
        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly DBContext _dbContext;
            public Handler(DBContext _context)
            {
                _dbContext = _context;
            }
            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                var requestSalaryAdvance = _dbContext.SalaryAdvanceRequests.Find(request.sar.RequestId);
                requestSalaryAdvance.Status = SalaryAdvanceStatus.Rejected;
                _dbContext.SalaryAdvanceRequests.Update(requestSalaryAdvance);

                //_dbContext.Entry(request.employee).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return new Response(request.sar);
            }
        }
        public record Response(SalaryAdvanceRequest sar) { }
    }
}

