using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Responses;

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

		public void SetupGetAllAsync(
			GetAllChatMessagesQuery query,
			ChatMessageCollectionResponse response,
			CancellationToken cancellationToken)
		{
			commentService
				.GetAllAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void SetupGetByIdAsync(
			GetChatMessageByIdQueryRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			commentService.SetupGetByIdAsync(request.IsGetChatMessageByIdQuery(), chatMessage.ToResponse(request), cancellationToken);
		}

		public void SetupGetByIdAsync(
			GetChatMessageByIdQuery query,
			ChatMessageResponse response,
			CancellationToken cancellationToken)
		{
			commentService
				.GetByIdAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
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

		public void SetupAddAsync(
			AddChatMessageCommand command,
			ChatMessageId id,
			CancellationToken cancellationToken)
		{
			commentService
				.AddAsync(command, cancellationToken)
				.ReturnsTaskResponse(id);
		}

		public void SetupUpdateAsync(
			UpdateChatMessageCommandRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			commentService.SetupUpdateAsync(request.IsUpdateChatMessageCommand(), chatMessage.ToResponse(request), cancellationToken);
		}

		public void SetupUpdateAsync(
			UpdateChatMessageCommand command,
			ChatMessageId id,
			CancellationToken cancellationToken)
		{
			commentService
				.UpdateAsync(command, cancellationToken)
				.ReturnsTaskResponse(id);
		}
	}
}
