using MediatR;
using Microsoft.EntityFrameworkCore;
using SalaryAdvance.Domain.Entities;
using SalaryAdvance.Infrastructure;

namespace SalaryAdvance.Application.Queries
{
    public class GetAllEmployeesQuery
    {
        public record GetAllEmployees : IRequest<Response>;
        public class Handler : IRequestHandler<GetAllEmployees, Response>
        {
            private readonly DBContext _context;

            public Handler(DBContext context)
            {
                _context = context;
            }

            public async Task<Response> Handle(GetAllEmployees request, CancellationToken cancellationToken)
            {
                var response = _context.Employees.ToListAsync().Result;
                return new Response(response);

            }
        }

        public record Response(List<Employee> employee) { }
    }
}
