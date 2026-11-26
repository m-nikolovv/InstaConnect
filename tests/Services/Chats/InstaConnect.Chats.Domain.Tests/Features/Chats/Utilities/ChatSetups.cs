
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

		public async Task<ChatResponse?> GetChatCacheByIdAsync(
			GetChatByIdQuery query,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetChatCacheByIdAsync(query.Id, query.CurrentUser.Id, cancellationToken);
		}

		public async Task SetupAddAsync(
			AddChatCommand command,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddAsync(chat, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllChatsQuery query,
			ICollection<Chat> chats,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllAsync(chats, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetChatByIdQuery query,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetByIdAsync(chat, cancellationToken);
		}
	}
}
