using InstaConnect.Common.Application.Tests.Features.Utilities;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupSendAsync(
		GetAllChatMessagesApiRequest request,
		Chat chat,
		ICollection<ChatMessage> chatMessages,
		CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsGetAllChatMessagesQueryRequest(), chatMessages.ToResponse(request, chat), cancellationToken);
		}

		public void SetupSendAsync(
			GetChatMessageByIdApiRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsGetChatMessageByIdQueryRequest(), chatMessage.ToResponse(request), cancellationToken);
		}

		public void SetupSendAsync(
			AddChatMessageApiRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsAddChatMessageCommandRequest(), chatMessage.ToResponse(request), cancellationToken);
		}

		public void SetupSendAsync(
			UpdateChatMessageApiRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsUpdateChatMessageCommandRequest(), chatMessage.ToResponse(request), cancellationToken);
		}
	}
}
