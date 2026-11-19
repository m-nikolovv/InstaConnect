using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Follows.Events.Features.Follows;

using MassTransit;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;

internal static class RiderRegistrationConfiguratorExtensions
{
	extension(IRiderRegistrationConfigurator riderConfigurator)
	{
		public IRiderRegistrationConfigurator MapFollowEventProducer()
		{
			riderConfigurator
				.MapEventProducer<FollowAddedEventRequest>(message => message.Follow.GetKey())
				.MapEventProducer<FollowDeletedEventRequest>(message => message.Follow.GetKey());

			return riderConfigurator;
		}
	}
}
