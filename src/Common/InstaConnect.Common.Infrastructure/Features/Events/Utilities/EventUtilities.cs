using MassTransit;

namespace InstaConnect.Common.Infrastructure.Features.Events.Utilities;

public static class EventUtilities
{
	public static string GetName<TEvent>()
		where TEvent : class
	{
		return KebabCaseEndpointNameFormatter.Instance.Message<TEvent>();
	}
}
