using InstaConnect.Common.Events.Features.Events.Abstractions;

using MassTransit;

namespace InstaConnect.Common.Infrastructure.Features.Events.Utilities;

public static class EventUtilities
{
	public static string GetName<TEventRequest>()
		where TEventRequest : class, IEventRequest
	{
		return KebabCaseEndpointNameFormatter.Instance.Message<TEventRequest>();
	}
}
