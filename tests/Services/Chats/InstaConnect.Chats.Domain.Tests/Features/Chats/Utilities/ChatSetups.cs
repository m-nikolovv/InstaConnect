
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
			User participantOne,
			User participantTwo,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddChatAsync(participantOne, participantTwo, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllChatsQuery query,
			ICollection<User> participantOnes,
			ICollection<User> participantTwos,
			ICollection<Chat> chats,
			ICollection<ChatMessage> chatMessages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllChatsAsync(participantOnes, participantTwos, chats, chatMessages, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetChatByIdQuery query,
			User participantOne,
			User participantTwo,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetChatByIdAsync(participantOne, participantTwo, chat, cancellationToken);
		}
	}
}
