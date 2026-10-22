using InstaConnect.Common.Events.Features.Events.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.Events.Abstractions;

public interface IEventKeySelectorProvider
{
	public IEventKeySelector<TEvent> GetKeySelector<TEvent>()
		where TEvent : class, IEventRequest;
}
