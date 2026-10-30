using InstaConnect.Common.Events.Features.Events.Abstractions;

using MassTransit;

namespace InstaConnect.Common.Infrastructure.Features.Events.Extensions;

public static class RiderRegistrationConfiguratorExtensions
{
	extension(IRiderRegistrationConfigurator riderConfigurator)
	{
		public IRiderRegistrationConfigurator MapEventProducer<TEvent>(Func<TEvent, string> keySelector)
			where TEvent : class, IEventRequest
		{
			riderConfigurator.AddProducer<string, TEvent>(KebabCaseEndpointNameFormatter.Instance.Message<TEvent>(), context => keySelector(context.Message));
			riderConfigurator.AddSingleton(keySelector);

			return riderConfigurator;
		}
	}
}
