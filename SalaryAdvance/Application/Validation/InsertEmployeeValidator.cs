using FluentValidation;
using SalaryAdvance.Domain.Entities;

namespace SalaryAdvance.Application.Validation
{
    public class InsertEmployeeValidator : AbstractValidator<Employee>
    {
        public InsertEmployeeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Employee name is required.");

            RuleFor(x => x.Salary)
                .GreaterThan(0).WithMessage("Salary must be greater than 0.");
        }
    }
}
