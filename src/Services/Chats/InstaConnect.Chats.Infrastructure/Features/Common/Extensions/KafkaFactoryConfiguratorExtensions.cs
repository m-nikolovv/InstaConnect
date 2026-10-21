using InstaConnect.Chats.Infrastructure.Features.Users.EventHandlers;
using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Identity.Events.Features.Users;

using MassTransit;

namespace InstaConnect.Chats.Infrastructure.Features.Common.Extensions;

public static class KafkaFactoryConfiguratorExtensions
{
	extension(IKafkaFactoryConfigurator kafkaConfigurator)
	{
		public IKafkaFactoryConfigurator MapUserEventHandler(IRiderRegistrationContext context, string prefix)
		{
			kafkaConfigurator
					.MapEventHandler<UserAddedEventRequest, UserAddedEventHandler>(context, prefix)
					.MapEventHandler<UserUpdatedEventRequest, UserUpdatedEventHandler>(context, prefix)
					.MapEventHandler<UserDeletedEventRequest, UserDeletedEventHandler>(context, prefix);

			return kafkaConfigurator;
		}
	}
}
