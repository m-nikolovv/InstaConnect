using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Domain.Features.Chats.Models.Responses;
using InstaConnect.Chats.Domain.Features.Chats.Models.ValueObjects;

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

		public void SetupGetAllAsync(
			GetAllChatsQuery query,
			ChatCollectionResponse response,
			CancellationToken cancellationToken)
		{
			service
				.GetAllAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
		}

		public void SetupGetByIdAsync(
			GetChatByIdQueryRequest request,
			Chat chat,
			CancellationToken cancellationToken)
		{
			service.SetupGetByIdAsync(request.IsGetChatByIdQuery(), chat.ToResponse(request), cancellationToken);
		}

		public void SetupGetByIdAsync(
			GetChatByIdQuery query,
			ChatResponse response,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(query, cancellationToken)
				.ReturnsTaskResponse(response);
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

		public void SetupAddAsync(
			AddChatCommand command,
			ChatId id,
			CancellationToken cancellationToken)
		{
			service
				.AddAsync(command, cancellationToken)
				.ReturnsTaskResponse(id);
		}
	}
}
