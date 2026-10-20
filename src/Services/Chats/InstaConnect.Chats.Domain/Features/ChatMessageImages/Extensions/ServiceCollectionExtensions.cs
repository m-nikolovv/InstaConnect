namespace InstaConnect.Chats.Domain.Features.ChatMessageImages.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddChatMessageImageServices()
		{
			return serviceCollection;
		}
	}
}
