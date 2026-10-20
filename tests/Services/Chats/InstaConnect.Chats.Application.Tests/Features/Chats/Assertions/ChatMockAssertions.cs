using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Assertions;

namespace InstaConnect.Chats.Application.Tests.Features.Chats.Assertions;

public static class ChatMockAssertions
{
	extension(IChatQueryService chatService)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
		GetAllChatsQueryRequest request,
		CancellationToken cancellationToken)
		{
			await chatService.ShouldHaveReceivedOneGetAllAsync(request.IsGetAllChatsQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetChatByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await chatService.ShouldHaveReceivedOneGetByIdAsync(request.IsGetChatByIdQuery(), cancellationToken);
		}
	}

	extension(IChatCommandService chatService)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
		AddChatCommandRequest request,
		CancellationToken cancellationToken)
		{
			await chatService.ShouldHaveReceivedOneAddAsync(request.IsAddChatCommand(), cancellationToken);
		}
	}
}
