namespace SalaryAdvance.Domain.Entities
{
    public class Employee
    {
        public int? EmployeeId { get; set; }
        public string? Name { get; set; }
        public double Salary { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
