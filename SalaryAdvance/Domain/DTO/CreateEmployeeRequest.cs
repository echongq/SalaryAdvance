namespace SalaryAdvance.Domain.DTO
{
    public class CreateEmployeeRequest
    {
        public string Name { get; set; } = string.Empty;
        public decimal MonthlySalary { get; set; }
    }
}
