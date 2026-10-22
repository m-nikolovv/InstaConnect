using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Events.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.Events.Helpers;

internal class EventKeySelectorProvider : IEventKeySelectorProvider
{
	private readonly IServiceProvider _serviceProvider;

	public EventKeySelectorProvider(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
	}

	public IEventKeySelector<TEvent> GetKeySelector<TEvent>()
		where TEvent : class, IEventRequest
	{
		return _serviceProvider.GetRequiredService<IEventKeySelector<TEvent>>();
	}
}
