using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Follows.Events.Features.Follows;
using InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;

using MassTransit;

namespace InstaConnect.Follows.Infrastructure.Features.Common.Extensions;

public static class RiderRegistrationConfiguratorExtensions
{
	extension(IRiderRegistrationConfigurator riderConfigurator)
	{
		public IRiderRegistrationConfigurator MapFollowEventProducer()
		{
			riderConfigurator
				.MapEventProducer<FollowAddedEventRequest>(context => context.Message.Follow.GetKey())
				.MapEventProducer<FollowDeletedEventRequest>(context => context.Message.Follow.GetKey());

			return riderConfigurator;
		}
	}
}
