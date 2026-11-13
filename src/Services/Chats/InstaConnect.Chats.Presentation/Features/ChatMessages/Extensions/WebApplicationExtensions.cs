using InstaConnect.Chats.Presentation.Features.ChatMessages.Helpers;
using InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Options;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Extensions;

public static class WebApplicationExtensions
{
	extension(WebApplication application)
	{
		public WebApplication MapChatMessageHub()
		{
			var options = application.Services.GetRequiredService<ChatMessageOptions>();

			application.MapHub<ChatMessageHub>(options.HubRoute);

			return application;
		}
	}
}
