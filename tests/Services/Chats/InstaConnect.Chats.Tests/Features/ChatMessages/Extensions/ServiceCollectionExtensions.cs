using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddChatMessageMockSummarizer()
		{
			serviceCollection.AddSingleton(_ => ChatMessageMockFactory.CreateSummarizer());

			return serviceCollection;
		}
	}
}
