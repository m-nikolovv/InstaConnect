using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;

namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageMockSetups
{
	extension(IChatMessageQueryService commentService)
	{
		public void SetupGetAllAsync(
		GetAllChatMessagesQueryRequest request,
		Chat chat,
		ICollection<ChatMessage> chatMessages,
		CancellationToken cancellationToken)
		{
			commentService.SetupGetAllAsync(request.IsGetAllChatMessagesQuery(), chatMessages.ToResponse(request, chat), cancellationToken);
		}

		public void SetupGetByIdAsync(
			GetChatMessageByIdQueryRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			commentService.SetupGetByIdAsync(request.IsGetChatMessageByIdQuery(), chatMessage.ToResponse(request), cancellationToken);
		}
	}

	extension(IChatMessageCommandService commentService)
	{
		public void SetupAddAsync(
		AddChatMessageCommandRequest request,
		ChatMessage chatMessage,
		CancellationToken cancellationToken)
		{
			commentService.SetupAddAsync(request.IsAddChatMessageCommand(), chatMessage.ToResponse(request), cancellationToken);
		}

		public void SetupUpdateAsync(
			UpdateChatMessageCommandRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			commentService.SetupUpdateAsync(request.IsUpdateChatMessageCommand(), chatMessage.ToResponse(request), cancellationToken);
		}
	}
}
