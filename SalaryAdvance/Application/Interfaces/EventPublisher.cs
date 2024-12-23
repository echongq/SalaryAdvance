using Newtonsoft.Json;
using SalaryAdvance.Domain.Entities;
using SalaryAdvance.Domain.Events;
using SalaryAdvance.Infrastructure;

namespace SalaryAdvance.Application.Interfaces
{
    public class EventPublisher : IEventPublisher
    {
        private readonly DBContext _context;

        public EventPublisher(DBContext context)
        {
            _context = context;
        }

        public async Task PublishAsync(DomainEvent domainEvent, CancellationToken cancellationToken = default)
        {
            // Persistir el evento en la tabla Audit.EventLog
            var eventLog = new EventLog
            {
                EventType = domainEvent.GetType().Name,
                Timestamp = domainEvent.Timestamp,
                Data = JsonConvert.SerializeObject(domainEvent)
            };

            _context.EventLogs.Add(eventLog);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
