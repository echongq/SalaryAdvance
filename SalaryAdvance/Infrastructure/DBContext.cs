namespace SalaryAdvance.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using SalaryAdvance.Domain.Entities;

    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        // DbSets para las entidades
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SalaryAdvanceRequest> SalaryAdvanceRequests { get; set; }
        public DbSet<Domain.Entities.EventLog> EventLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Salary");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employees");
                entity.HasKey(e => e.EmployeeId);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Salary).IsRequired();
            });

            modelBuilder.Entity<SalaryAdvanceRequest>(entity =>
            {
                entity.ToTable("SalaryAdvanceRequests");
                entity.HasKey(s => s.RequestId);
                entity.Property(s => s.EmployeeId).IsRequired();
                entity.Property(s => s.Amount).IsRequired();
                entity.Property(s => s.Reason).IsRequired();
                entity.Property(s => s.Status).IsRequired();
            });

            modelBuilder.Entity<Domain.Entities.EventLog>(entity =>
            {
                entity.ToTable("EventLog", "Audit");
                entity.HasKey(e => e.EventLogId);
                entity.Property(e => e.EventType);
                entity.Property(e => e.Timestamp);
                entity.Property(e => e.Data);
            });
        }
    }
}
