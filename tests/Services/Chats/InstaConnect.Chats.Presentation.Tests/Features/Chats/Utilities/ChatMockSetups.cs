using InstaConnect.Common.Application.Tests.Features.Utilities;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;

public static class ChatMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupSendAsync(
		GetAllChatsApiRequest request,
		User participantOne,
		ICollection<Chat> chats,
		CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsGetAllChatsQueryRequest(), chats.ToResponse(request, participantOne), cancellationToken);
		}

		public void SetupSendAsync(
			GetChatByIdApiRequest request,
			Chat chat,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsGetChatByIdQueryRequest(), chat.ToResponse(request), cancellationToken);
		}

		public void SetupSendAsync(
			AddChatApiRequest request,
			Chat chat,
			CancellationToken cancellationToken)
		{
			sender.SetupSendAsync(request.IsAddChatCommandRequest(), chat.ToResponse(request), cancellationToken);
		}
	}
}
