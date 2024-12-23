using MediatR;
using Microsoft.EntityFrameworkCore;
using SalaryAdvance.Domain.Entities;
using SalaryAdvance.Infrastructure;

namespace SalaryAdvance.Application.Queries
{
    public class GetSalaryAdvanceRequestsQuery
    {
        public record GetRequestsQuery(Guid RequestId) : IRequest<Response>;


        public class Handler : IRequestHandler<GetRequestsQuery, Response>
        {
            private readonly DBContext _context;

            public Handler(DBContext context)
            {
                _context = context;
            }

            public async Task<Response> Handle(GetRequestsQuery request, CancellationToken cancellationToken)
            {
                var sarList = _context.SalaryAdvanceRequests.Find(request.RequestId);
                return new Response(sarList);
            }
        }
        public record Response(SalaryAdvanceRequest sarList) { }
    }
}