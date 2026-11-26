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
			User participantOne,
			User participantTwo,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddChatAsync(participantOne, participantTwo, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllChatsQueryRequest request,
			ICollection<User> participantOnes,
			ICollection<User> participantTwos,
			ICollection<Chat> chats,
			ICollection<ChatMessage> chatMessages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllChatsAsync(participantOnes, participantTwos, chats, chatMessages, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetChatByIdQueryRequest request,
			User participantOne,
			User participantTwo,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetChatByIdAsync(participantOne, participantTwo, chat, cancellationToken);
		}
	}
}
