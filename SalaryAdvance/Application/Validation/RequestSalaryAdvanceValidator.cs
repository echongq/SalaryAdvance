using FluentValidation;
using SalaryAdvance.Domain.Entities;

namespace SalaryAdvance.Application.Validation
{
    public class RequestSalaryAdvanceValidator : AbstractValidator<SalaryAdvanceRequest>
    {
        public RequestSalaryAdvanceValidator()
        {
            RuleFor(x => x.EmployeeId)
                .NotNull().NotEmpty().WithMessage("Employee Id is required.");
            RuleFor(x => x.Reason)
                .NotNull().NotEmpty().WithMessage("Reason is required.");
            RuleFor(x => x.Amount)
                .NotNull().NotEmpty().WithMessage("Reason is required.");
            RuleFor(x => x.Amount)
                .NotNull().NotEmpty().WithMessage("Reason is required.");
            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Requested Amount must be greater than 0.");
        }
    }
}
