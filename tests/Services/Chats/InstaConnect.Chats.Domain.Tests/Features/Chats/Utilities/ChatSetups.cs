
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

		public async Task InitializeAddAsync(
			AddChatCommand command,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(chat, cancellationToken);
		}

		public async Task DisposeAddAsync(
			AddChatCommand command,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(chat, cancellationToken);
		}

		public async Task InitializeGetAllAsync(
			GetAllChatsQuery query,
			ICollection<Chat> chats,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllAsync(chats, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			GetAllChatsQuery query,
			ICollection<Chat> chats,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllAsync(chats, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			GetChatByIdQuery query,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetByIdAsync(chat, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			GetChatByIdQuery query,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetByIdAsync(chat, cancellationToken);
		}
	}
}
