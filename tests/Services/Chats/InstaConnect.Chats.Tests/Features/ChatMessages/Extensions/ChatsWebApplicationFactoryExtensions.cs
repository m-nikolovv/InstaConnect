using InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Options;
using InstaConnect.Chats.Tests.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Tests.Features.ChatMessages.Helpers;
using InstaConnect.Common.Tests.Features.Extensions;

using Microsoft.Extensions.Options;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Extensions;

public static class ChatsWebApplicationFactoryExtensions
{
	extension(ChatsWebApplicationFactory webApplicationFactory)
	{
		public IChatMessageNotificationClient CreateMessageNotificationClient(UserId participantTwoId)
		{
			var hubRoute = webApplicationFactory.Services
				.GetRequiredService<IOptions<ChatMessageOptions>>()
				.Value
				.HubRoute;

			var connection = webApplicationFactory.CreateHubConnection(participantTwoId.Id, hubRoute.TrimLeadingSlash());

			return new ChatMessageNotificationClient(connection);
		}
	}
}
