using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Responses;
using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageDomainSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IChatMessageCommandService GetChatMessageCommandService()
		{
			return serviceProvider.GetRequiredService<IChatMessageCommandService>();
		}

		public IChatMessageQueryService GetChatMessageQueryService()
		{
			return serviceProvider.GetRequiredService<IChatMessageQueryService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IChatMessageCommandService GetChatMessageCommandService()
		{
			return serviceScope.ServiceProvider.GetChatMessageCommandService();
		}

		public IChatMessageQueryService GetChatMessageQueryService()
		{
			return serviceScope.ServiceProvider.GetChatMessageQueryService();
		}
	}

	extension(IChatMessageCacheHandler cacheHandler)
	{
		public async Task<ChatMessageResponse?> GetByIdAsync(
			UpdateChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(command.Id, command.Id.Id.ParticipantOneId, cancellationToken);
		}

		public async Task<ChatMessageResponse?> GetByIdAsync(
			DeleteChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(command.Id, command.Id.Id.ParticipantOneId, cancellationToken);
		}

		public async Task<ChatMessageResponse?> GetByIdAsync(
			GetChatMessageByIdQuery query,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(query.Id, query.CurrentUser.Id, cancellationToken);
		}
	}

	extension(IChatCacheHandler cacheHandler)
	{
		public async Task<ChatResponse?> GetByIdAsync(
			AddChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(command.Id, command.Id.ParticipantOneId, cancellationToken);
		}

		public async Task<ChatResponse?> GetByIdAsync(
			DeleteChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(command.Id.Id, command.Id.Id.ParticipantOneId, cancellationToken);
		}
	}
}
