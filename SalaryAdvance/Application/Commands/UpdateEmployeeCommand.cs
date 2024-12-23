using MediatR;
using Microsoft.EntityFrameworkCore;
using SalaryAdvance.Domain.Entities;
using SalaryAdvance.Infrastructure;

namespace SalaryAdvance.Application.Commands
{
    public class UpdateEmployeeCommand
    {
        public record Command(Employee employee) : IRequest<Response> { }
        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly DBContext _dbContext;
            public Handler(DBContext _context) {
                _dbContext = _context;
            }
            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                //var employee = _dbContext.Employees.Find(request.employee.EmployeeId);

                _dbContext.Employees.Update(request.employee);

                //_dbContext.Entry(request.employee).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return new Response(request.employee);
            }
        }
        public record Response (Employee employee) { }
    }
}
