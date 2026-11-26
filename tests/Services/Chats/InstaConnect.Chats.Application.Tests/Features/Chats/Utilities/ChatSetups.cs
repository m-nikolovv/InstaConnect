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

		public async Task InitializeAddAsync(
			AddChatCommandRequest request,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(chat, cancellationToken);
		}

		public async Task DisposeAddAsync(
			AddChatCommandRequest request,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(chat, cancellationToken);
		}

		public async Task InitializeGetAllAsync(
			GetAllChatsQueryRequest request,
			ICollection<Chat> chats,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllAsync(chats, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			GetAllChatsQueryRequest request,
			ICollection<Chat> chats,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllAsync(chats, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			GetChatByIdQueryRequest request,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetByIdAsync(chat, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			GetChatByIdQueryRequest request,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetByIdAsync(chat, cancellationToken);
		}
	}
}
