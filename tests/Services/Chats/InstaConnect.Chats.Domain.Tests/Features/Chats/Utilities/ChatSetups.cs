using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;

public static class ChatDomainSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IChatCommandService GetChatCommandService()
		{
			return serviceProvider.GetRequiredService<IChatCommandService>();
		}

		public IChatQueryService GetChatQueryService()
		{
			return serviceProvider.GetRequiredService<IChatQueryService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IChatCommandService GetChatCommandService()
		{
			return serviceScope.ServiceProvider.GetChatCommandService();
		}

		public IChatQueryService GetChatQueryService()
		{
			return serviceScope.ServiceProvider.GetChatQueryService();
		}
	}

	extension(IChatCacheHandler cacheHandler)
	{
		public async Task<ChatResponse?> GetByIdAsync(
			GetChatByIdQuery query,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(query.Id, query.CurrentUser.Id, cancellationToken);
		}
	}
}
