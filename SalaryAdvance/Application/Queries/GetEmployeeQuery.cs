using MediatR;
using SalaryAdvance.Domain.Entities;
using SalaryAdvance.Infrastructure;

namespace SalaryAdvance.Application.Commands.Queries
{
    public class GetEmployeeQuery
    {
        public record GetByIdQuery(int? EmployeeId) : IRequest<Response>;
        public class Handler : IRequestHandler<GetByIdQuery, Response>
        {
            private readonly DBContext _dbContext;
            public Handler(DBContext _context) {
                _dbContext = _context;
            }
            public async Task<Response> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                var employee = _dbContext.Employees.Find(request.EmployeeId);
                return new Response(employee);
            }
        }
        public record Response (Employee employee) { }
    }
}
