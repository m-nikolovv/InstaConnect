using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Presentation.Features.ChatMessages.Helpers;
using InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Options;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddChatMessageServices()
		{
			serviceCollection.AddValidatedOptions<ChatMessageOptions>(ChatMessageOptions.SectionName);

			serviceCollection.AddScoped<IChatMessageNotificationService, ChatMessageNotificationService>();

			return serviceCollection;
		}
	}
}
