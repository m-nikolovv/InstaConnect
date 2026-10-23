using InstaConnect.Common.Events.Features.Events.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.Events.Abstractions;

public interface IEventKeySelectorProvider
{
	public Func<TEvent, string> GetKeySelector<TEvent>()
		where TEvent : class, IEventRequest;
}
