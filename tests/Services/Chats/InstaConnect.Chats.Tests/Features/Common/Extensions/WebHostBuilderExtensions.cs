using InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Options;

using Microsoft.AspNetCore.Hosting;

namespace InstaConnect.Chats.Tests.Features.Common.Extensions;

public static class WebHostBuilderExtensions
{
	extension(IWebHostBuilder webHostBuilder)
	{
		public void UpdateChatMessageConfiguration()
		{
			webHostBuilder.UseSetting(
				ChatMessageOptions.SectionName.ToSectionKey(nameof(ChatMessageOptions.HubRoute)),
				ChatsMockValues.ChatMessageHubRoute);
		}
	}
}
