namespace InstaConnect.Common.Events.Features.Events.Abstractions;

public interface IEventPublisher
{
	public Task PublishAsync<TEvent>(TEvent message, CancellationToken cancellationToken)
		where TEvent : class, IEventRequest;

	public Task PublishRangeAsync<TEvent>(ICollection<TEvent> messages, CancellationToken cancellationToken)
		where TEvent : class, IEventRequest;
}
