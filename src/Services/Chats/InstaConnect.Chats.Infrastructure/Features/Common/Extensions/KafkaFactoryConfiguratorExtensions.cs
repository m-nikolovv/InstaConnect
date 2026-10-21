using InstaConnect.Chats.Infrastructure.Features.Common.Utilities;
using InstaConnect.Chats.Infrastructure.Features.Users.EventHandlers;
using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Identity.Events.Features.Users;

using MassTransit;

namespace InstaConnect.Chats.Infrastructure.Features.Common.Extensions;

public static class KafkaFactoryConfiguratorExtensions
{
	extension(IKafkaFactoryConfigurator kafkaConfigurator)
	{
		public IKafkaFactoryConfigurator MapUserEventHandler(IRiderRegistrationContext context)
		{
			kafkaConfigurator
					.MapEventHandler<UserAddedEventRequest, UserAddedEventHandler>(context, ChatsEventHandlerUtilities.GroupId)
					.MapEventHandler<UserUpdatedEventRequest, UserUpdatedEventHandler>(context, ChatsEventHandlerUtilities.GroupId)
					.MapEventHandler<UserDeletedEventRequest, UserDeletedEventHandler>(context, ChatsEventHandlerUtilities.GroupId);

			return kafkaConfigurator;
		}
	}
}
