using InstaConnect.Common.Events.Features.Events.Abstractions;

using MassTransit;
using MassTransit.KafkaIntegration;

namespace InstaConnect.Common.Infrastructure.Features.Events.Extensions;

public static class RiderRegistrationConfiguratorExtensions
{
	extension(IRiderRegistrationConfigurator riderConfigurator)
	{
		public IRiderRegistrationConfigurator MapEventProducer<TEvent>(KafkaKeyResolver<string, TEvent> keyResolver)
			where TEvent : class, IEventRequest
		{
			riderConfigurator.AddProducer(KebabCaseEndpointNameFormatter.Instance.Message<TEvent>(), keyResolver);

			return riderConfigurator;
		}
	}
}
