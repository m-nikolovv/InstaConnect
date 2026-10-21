using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Posts.Infrastructure.Features.Users.EventHandlers;

using MassTransit;

namespace InstaConnect.Posts.Infrastructure.Features.Common.Extensions;

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
