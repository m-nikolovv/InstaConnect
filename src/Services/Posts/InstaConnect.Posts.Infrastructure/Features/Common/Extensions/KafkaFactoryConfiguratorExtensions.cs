using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Common.Infrastructure.Features.Events.Models;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Posts.Infrastructure.Features.Users.EventHandlers;

using MassTransit;

namespace InstaConnect.Posts.Infrastructure.Features.Common.Extensions;

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
