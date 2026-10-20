using InstaConnect.Chats.Tests.Features.Chats.Abstractions;
using InstaConnect.Chats.Tests.Features.Chats.Helpers;

namespace InstaConnect.Chats.Tests.Features.Chats.Extensions;

public static class ChatsWebApplicationFactoryExtensions
{
	extension(ChatsWebApplicationFactory webApplicationFactory)
	{
		public IChatEventClient CreateEventClient()
		{
			var eventClient = webApplicationFactory.Services.GetEventClient();

			return new ChatEventClient(eventClient);
		}
	}
}
