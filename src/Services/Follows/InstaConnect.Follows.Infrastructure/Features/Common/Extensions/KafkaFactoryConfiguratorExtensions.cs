using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Follows.Infrastructure.Features.Common.Utilities;
using InstaConnect.Follows.Infrastructure.Features.Users.EventHandlers;
using InstaConnect.Identity.Events.Features.Users;

using MassTransit;

namespace InstaConnect.Follows.Infrastructure.Features.Common.Extensions;

public static class KafkaFactoryConfiguratorExtensions
{
	extension(IKafkaFactoryConfigurator kafkaConfigurator)
	{
		public IKafkaFactoryConfigurator MapUserEventHandler(IRiderRegistrationContext context)
		{
			kafkaConfigurator
					.MapEventHandler<UserAddedEventRequest, UserAddedEventHandler>(context, FollowsEventHandlerUtilities.GroupId)
					.MapEventHandler<UserUpdatedEventRequest, UserUpdatedEventHandler>(context, FollowsEventHandlerUtilities.GroupId)
					.MapEventHandler<UserDeletedEventRequest, UserDeletedEventHandler>(context, FollowsEventHandlerUtilities.GroupId);

			return kafkaConfigurator;
		}
	}
}
