using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Posts.Infrastructure.Features.Users.EventHandlers;

using MassTransit;

namespace InstaConnect.Posts.Infrastructure.Features.Common.Extensions;

public static class KafkaFactoryConfiguratorExtensions
{
	extension(IKafkaFactoryConfigurator kafkaConfigurator)
	{
		public IKafkaFactoryConfigurator MapUserEventHandler(IRiderRegistrationContext context, string groupId)
		{
			kafkaConfigurator
					.MapEventHandler<UserAddedEventRequest, UserAddedEventHandler>(context, groupId)
					.MapEventHandler<UserUpdatedEventRequest, UserUpdatedEventHandler>(context, groupId)
					.MapEventHandler<UserDeletedEventRequest, UserDeletedEventHandler>(context, groupId);

			return kafkaConfigurator;
		}
	}
}
