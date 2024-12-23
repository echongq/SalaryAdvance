using MediatR;
using SalaryAdvance.Domain.Entities;
using SalaryAdvance.Infrastructure;

namespace SalaryAdvance.Application.Commands
{
    public class DeleteEmployeeCommand
    {
        public record Command(int EmployeeId, bool isDeleted) : IRequest<Response> { }
        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly DBContext _dbContext;
            public Handler(DBContext _context) {
                _dbContext = _context;
            }
            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                var employee = _dbContext.Employees.Find(request.EmployeeId);
                employee.IsDeleted = request.isDeleted;
                _dbContext.Employees.Update(employee);
                _dbContext.SaveChanges();
                return new Response(employee);
            }
        }
        public record Response (Employee employee) { }
    }
}
