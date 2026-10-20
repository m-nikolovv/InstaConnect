using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Application.Tests.Features.Chats.Utilities;

public static class ChatMockSetups
{
	extension(IChatQueryService service)
	{
		public void SetupGetAllAsync(
		GetAllChatsQueryRequest request,
		User participantOne,
		ICollection<Chat> chats,
		CancellationToken cancellationToken)
		{
			service.SetupGetAllAsync(request.IsGetAllChatsQuery(), chats.ToResponse(request, participantOne), cancellationToken);
		}

		public void SetupGetByIdAsync(
			GetChatByIdQueryRequest request,
			Chat chat,
			CancellationToken cancellationToken)
		{
			service.SetupGetByIdAsync(request.IsGetChatByIdQuery(), chat.ToResponse(request), cancellationToken);
		}
	}

	extension(IChatCommandService service)
	{
		public void SetupAddAsync(
		AddChatCommandRequest request,
		Chat chat,
		CancellationToken cancellationToken)
		{
			service.SetupAddAsync(request.IsAddChatCommand(), chat.ToResponse(request), cancellationToken);
		}
	}
}
