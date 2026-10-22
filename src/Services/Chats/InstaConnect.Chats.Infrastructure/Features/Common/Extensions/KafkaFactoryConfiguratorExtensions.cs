using InstaConnect.Chats.Infrastructure.Features.Users.EventHandlers;
using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Common.Infrastructure.Features.Events.Models;
using InstaConnect.Identity.Events.Features.Users;

using MassTransit;

namespace InstaConnect.Chats.Infrastructure.Features.Common.Extensions;

public static class KafkaFactoryConfiguratorExtensions
{
	extension(IKafkaFactoryConfigurator kafkaConfigurator)
	{
		public IKafkaFactoryConfigurator MapUserEventHandler(IRiderRegistrationContext context, string prefix, IDictionary<string, KafkaConsumerOptions> consumerOptions)
		{
			kafkaConfigurator
					.MapEventHandler<UserAddedEventRequest, UserAddedEventHandler>(context, prefix, consumerOptions)
					.MapEventHandler<UserUpdatedEventRequest, UserUpdatedEventHandler>(context, prefix, consumerOptions)
					.MapEventHandler<UserDeletedEventRequest, UserDeletedEventHandler>(context, prefix, consumerOptions);

			return kafkaConfigurator;
		}
	}
}
