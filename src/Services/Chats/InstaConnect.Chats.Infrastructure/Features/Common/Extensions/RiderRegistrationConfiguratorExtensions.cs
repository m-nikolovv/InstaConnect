using InstaConnect.Chats.Events.Features.Chats.Models;
using InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;
using InstaConnect.Common.Infrastructure.Features.Events.Extensions;

using MassTransit;

namespace InstaConnect.Chats.Infrastructure.Features.Common.Extensions;

public static class RiderRegistrationConfiguratorExtensions
{
	extension(IRiderRegistrationConfigurator riderConfigurator)
	{
		public IRiderRegistrationConfigurator MapChatEventProducer()
		{
			riderConfigurator
				.MapEventProducer<ChatAddedEventRequest>(message => message.Chat.GetKey());

			return riderConfigurator;
		}
	}
}
