using InstaConnect.Chats.Domain.Features.Chats.Abstractions;

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

		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllChatsQuery query,
			CancellationToken cancellationToken)
		{
			await chatService.ShouldHaveReceivedOne().GetAllAsync(query, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetChatByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await chatService.ShouldHaveReceivedOneGetByIdAsync(request.IsGetChatByIdQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetChatByIdQuery query,
			CancellationToken cancellationToken)
		{
			await chatService.ShouldHaveReceivedOne().GetByIdAsync(query, cancellationToken);
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

		public async Task ShouldHaveReceivedOneAddAsync(
			AddChatCommand command,
			CancellationToken cancellationToken)
		{
			await chatService.ShouldHaveReceivedOne().AddAsync(command, cancellationToken);
		}
	}
}
