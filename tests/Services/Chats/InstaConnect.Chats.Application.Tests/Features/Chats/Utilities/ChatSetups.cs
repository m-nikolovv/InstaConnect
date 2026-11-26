using InstaConnect.Chats.Application.Features.Chats.Models;
using InstaConnect.Chats.Domain.Features.Chats.Models.Responses;
using InstaConnect.Chats.Domain.Features.Chats.Models.ValueObjects;

namespace InstaConnect.Chats.Application.Tests.Features.Chats.Utilities;

public static class ChatSetups
{
	extension(IServiceScope serviceScope)
	{
		internal async Task<Chat?> GetByIdAsync(
		ChatIdCommandResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new ChatId(new(id.ParticipantOneId), new(id.ParticipantTwoId)),
				cancellationToken);
		}

		public async Task<Chat?> GetByIdAsync(
			AddChatCommandResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<ChatResponse?> GetChatCacheByIdAsync(
			GetChatByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetChatCacheByIdAsync(request.CurrentUserId, request.ParticipantTwoId, request.CurrentUserId, cancellationToken);
		}

		public async Task SetupAddAsync(
			AddChatCommandRequest request,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddAsync(chat, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllChatsQueryRequest request,
			ICollection<Chat> chats,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllAsync(chats, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetChatByIdQueryRequest request,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetByIdAsync(chat, cancellationToken);
		}
	}
}
