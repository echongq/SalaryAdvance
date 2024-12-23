using FluentValidation;
using SalaryAdvance.Domain.Entities;

namespace SalaryAdvance.Application.Validation
{
    public class UpdateEmployeeValidator : AbstractValidator<Employee>
    {
        public UpdateEmployeeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Employee name is required.");

            RuleFor(x => x.Salary)
                .GreaterThan(0).WithMessage("Salary must be greater than 0.");
        }
    }
}
