using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Assertions;

namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageMockAssertions
{
	extension(IChatMessageQueryService chatMessageService)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(GetAllChatMessagesQueryRequest request, CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOneGetAllAsync(request.IsGetAllChatMessagesQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(GetChatMessageByIdQueryRequest request, CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOneGetByIdAsync(request.IsGetChatMessageByIdQuery(), cancellationToken);
		}
	}

	extension(IChatMessageCommandService chatMessageService)
	{
		public async Task ShouldHaveReceivedOneAddAsync(AddChatMessageCommandRequest request, CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOneAddAsync(request.IsAddChatMessageCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(UpdateChatMessageCommandRequest request, CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOneUpdateAsync(request.IsUpdateChatMessageCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(DeleteChatMessageCommandRequest request, CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOneDeleteAsync(request.IsDeleteChatMessageCommand(), cancellationToken);
		}
	}
}
