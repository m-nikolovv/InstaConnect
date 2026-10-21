using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Posts.Infrastructure.Features.Common.Utilities;
using InstaConnect.Posts.Infrastructure.Features.Users.EventHandlers;

using MassTransit;

namespace InstaConnect.Posts.Infrastructure.Features.Common.Extensions;

public static class KafkaFactoryConfiguratorExtensions
{
	extension(IKafkaFactoryConfigurator kafkaConfigurator)
	{
		public IKafkaFactoryConfigurator MapUserEventHandler(IRiderRegistrationContext context)
		{
			kafkaConfigurator
					.MapEventHandler<UserAddedEventRequest, UserAddedEventHandler>(context, PostsEventHandlerUtilities.GroupId)
					.MapEventHandler<UserUpdatedEventRequest, UserUpdatedEventHandler>(context, PostsEventHandlerUtilities.GroupId)
					.MapEventHandler<UserDeletedEventRequest, UserDeletedEventHandler>(context, PostsEventHandlerUtilities.GroupId);

			return kafkaConfigurator;
		}
	}
}
