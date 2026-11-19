using InstaConnect.Chats.Infrastructure.Features.Users.EventHandlers;
using InstaConnect.Chats.Infrastructure.Features.Users.Models.Options;
using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Common.Infrastructure.Features.Events.Utilities;
using InstaConnect.Identity.Events.Features.Users;

using MassTransit;

using Microsoft.Extensions.Configuration;

namespace InstaConnect.Chats.Infrastructure.Features.Common.Extensions;

public static class KafkaFactoryConfiguratorExtensions
{
	extension(IKafkaFactoryConfigurator kafkaConfigurator)
	{
		public IKafkaFactoryConfigurator MapUserEventHandler(IRiderRegistrationContext context, string prefix)
		{
			var consumerOptions = context
				.GetRequiredService<IConfiguration>()
				.GetOptions<UserEventHandlerOptions>(UserEventHandlerOptions.SectionName)
				.Consumers;

			kafkaConfigurator
				.MapEventHandler<UserAddedEventRequest, UserAddedEventHandler>(context, prefix, consumerOptions[EventUtilities.GetName<UserAddedEventRequest>()])
				.MapEventHandler<UserUpdatedEventRequest, UserUpdatedEventHandler>(context, prefix, consumerOptions[EventUtilities.GetName<UserUpdatedEventRequest>()])
				.MapEventHandler<UserDeletedEventRequest, UserDeletedEventHandler>(context, prefix, consumerOptions[EventUtilities.GetName<UserDeletedEventRequest>()]);

			return kafkaConfigurator;
		}
	}
}
