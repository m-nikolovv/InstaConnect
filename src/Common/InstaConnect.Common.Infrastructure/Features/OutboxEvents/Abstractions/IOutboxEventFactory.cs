using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Models.Entities;

namespace InstaConnect.Common.Infrastructure.Features.OutboxEvents.Abstractions;

public interface IOutboxEventFactory
{
	public OutboxEvent Create<TEvent>(TEvent message)
		where TEvent : class, IEventRequest;

	public ICollection<OutboxEvent> CreateRange<TEvent>(ICollection<TEvent> messages)
		where TEvent : class, IEventRequest;
}
