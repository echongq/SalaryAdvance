using SalaryAdvance.Domain.Events;

namespace SalaryAdvance.Application.Interfaces
{
    public interface IEventPublisher
    {
        Task PublishAsync(DomainEvent domainEvent, CancellationToken cancellationToken = default);
    }
}
