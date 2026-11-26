using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;

namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageMockAssertions
{
	extension(IChatMessageQueryService chatMessageService)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(GetAllChatMessagesQueryRequest request, CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOneGetAllAsync(request.IsGetAllChatMessagesQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllChatMessagesQuery query,
			CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOne().GetAllAsync(query, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(GetChatMessageByIdQueryRequest request, CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOneGetByIdAsync(request.IsGetChatMessageByIdQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetChatMessageByIdQuery query,
			CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOne().GetByIdAsync(query, cancellationToken);
		}
	}

	extension(IChatMessageCommandService chatMessageService)
	{
		public async Task ShouldHaveReceivedOneAddAsync(AddChatMessageCommandRequest request, CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOneAddAsync(request.IsAddChatMessageCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			AddChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOne().AddAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(UpdateChatMessageCommandRequest request, CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOneUpdateAsync(request.IsUpdateChatMessageCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			UpdateChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOne().UpdateAsync(command, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(DeleteChatMessageCommandRequest request, CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOneDeleteAsync(request.IsDeleteChatMessageCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteChatMessageCommand command,
			CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOne().DeleteAsync(command, cancellationToken);
		}
	}
}
