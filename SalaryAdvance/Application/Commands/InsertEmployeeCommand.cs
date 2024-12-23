using MediatR;
using SalaryAdvance.Domain.Entities;
using SalaryAdvance.Infrastructure;

namespace SalaryAdvance.Application.Commands
{
    public class InsertEmployeeCommand
    {
        public record Command(Employee employee) : IRequest<Response>;
        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly DBContext _dbContext;
            public Handler(DBContext _context) {
                _dbContext = _context;
            }
            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                _dbContext.Employees.Add(request.employee);
                _dbContext.SaveChanges();
                return new Response(request.employee);
            }
        }
        public record Response (Employee employee) { }
    }
}
