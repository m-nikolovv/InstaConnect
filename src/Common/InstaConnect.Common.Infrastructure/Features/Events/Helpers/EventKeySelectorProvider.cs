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

	public Func<TEvent, string> GetKeySelector<TEvent>()
		where TEvent : class, IEventRequest
	{
		return _serviceProvider.GetRequiredService<Func<TEvent, string>>();
	}
}
