using MediatR;
using Microsoft.EntityFrameworkCore;
using SalaryAdvance.Domain.Entities;
using SalaryAdvance.Infrastructure;

namespace SalaryAdvance.Application.Queries
{
    public class GetSalaryAdvanceRequestsByEmployeeQuery
    {
        public record GetSalaryAdvanceRequestByEmployeeQuery(int EmployeeId) : IRequest<Response>;
        

        public class Handler : IRequestHandler<GetSalaryAdvanceRequestByEmployeeQuery, Response>
        {
            private readonly DBContext _context;

            public Handler(DBContext context)
            {
                _context = context;
            }

            public async Task<Response> Handle(GetSalaryAdvanceRequestByEmployeeQuery request, CancellationToken cancellationToken)
            {
                var sarList = _context.SalaryAdvanceRequests.Where(req => req.EmployeeId == request.EmployeeId);
                    //.Where(r => r.EmployeeId == request.EmployeeId)
                    //.ToListAsync();
                return new Response(sarList.ToList());
            }
        }
        public record Response(List<SalaryAdvanceRequest> sarList) { }
    }
}
