using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Add;
using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Update;
using InstaConnect.Chats.Application.Features.ChatMessages.Models;
using InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetAll;
using InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetById;
using InstaConnect.Chats.Presentation.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Presentation.Tests.Features.Users.Utilities;
using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageMapper
{
	extension(ChatMessage chatMessage)
	{
		internal ChatMessageIdCommandResponse ToIdCommandResponse(
)
		{
			return new(chatMessage.Id.Id.ParticipantOneId.Id, chatMessage.Id.Id.ParticipantTwoId.Id, chatMessage.Id.MessageId);
		}

		internal ChatMessageQueryResponse ToFullQueryResponse()
		{
			return new(chatMessage.Id.Id.ParticipantOneId.Id,
					   chatMessage.Id.Id.ParticipantTwoId.Id,
					   chatMessage.Id.MessageId,
					   chatMessage.SenderId.Id,
					   chatMessage.Content,
					   chatMessage.Summary.Value,
					   chatMessage.Chat?.ToFullQueryResponse(),
					   chatMessage.Sender?.ToFullQueryResponse(),
					   chatMessage.ChatMessageImages.ToFullQueryResponse(),
					   chatMessage.CreatedAtUtc,
					   chatMessage.UpdatedAtUtc);
		}

		internal ChatMessageQueryResponse ToQueryResponseWithoutSender()
		{
			return new(chatMessage.Id.Id.ParticipantOneId.Id,
					   chatMessage.Id.Id.ParticipantTwoId.Id,
					   chatMessage.Id.MessageId,
					   chatMessage.SenderId.Id,
					   chatMessage.Content,
					   chatMessage.Summary.Value,
					   chatMessage.Chat?.ToFullQueryResponse(),
					   null,
					   chatMessage.ChatMessageImages.ToFullQueryResponse(),
					   chatMessage.CreatedAtUtc,
					   chatMessage.UpdatedAtUtc);
		}

		internal ChatMessageQueryResponse ToQueryResponseWithoutChat()
		{
			return new(chatMessage.Id.Id.ParticipantOneId.Id,
					   chatMessage.Id.Id.ParticipantTwoId.Id,
					   chatMessage.Id.MessageId,
					   chatMessage.SenderId.Id,
					   chatMessage.Content,
					   chatMessage.Summary.Value,
					   null,
					   chatMessage.Sender?.ToFullQueryResponse(),
					   chatMessage.ChatMessageImages.ToFullQueryResponse(),
					   chatMessage.CreatedAtUtc,
					   chatMessage.UpdatedAtUtc);
		}

		public AddChatMessageCommandResponse ToResponse(
			AddChatMessageApiRequest request)
		{
			return new(chatMessage.ToIdCommandResponse());
		}

		public UpdateChatMessageCommandResponse ToResponse(
			UpdateChatMessageApiRequest request)
		{
			return new(chatMessage.ToIdCommandResponse());
		}

		public GetChatMessageByIdQueryResponse ToResponse(
			GetChatMessageByIdApiRequest request)
		{
			return new(chatMessage.ToFullQueryResponse());
		}
	}

	extension(ICollection<ChatMessage> chatMessages)
	{
		internal ChatMessageCollectionQueryResponse ToQueryResponseWithoutSender<TRequest>(
		TRequest request,
		Chat chat,
		Func<TRequest, ChatMessage, bool> filter,
		Func<TRequest, ChatMessage, ChatMessageQueryResponse> transform)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = chatMessages.Count(chatMessage => filter(request, chatMessage));

			return new(chat.ToFullQueryResponse(),
					   null,
					   chatMessages.Filter(request, chatMessage => filter(request, chatMessage), chatMessage => transform(request, chatMessage)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		internal ChatMessageCollectionQueryResponse ToQueryResponseWithoutChat<TRequest>(
			TRequest request,
			User user,
			Func<TRequest, ChatMessage, bool> filter,
			Func<TRequest, ChatMessage, ChatMessageQueryResponse> transform)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = chatMessages.Count(chatMessage => filter(request, chatMessage));

			return new(null,
					   user.ToFullQueryResponse(),
					   chatMessages.Filter(request, chatMessage => filter(request, chatMessage), chatMessage => transform(request, chatMessage)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		public GetAllChatMessagesQueryResponse ToResponse(
			GetAllChatMessagesApiRequest request,
			Chat chat)
		{
			return new(chatMessages.ToQueryResponseWithoutSender(
					   request,
					   chat,
					   (request, chatMessage) => chatMessage.MatchesFilter(request),
					   (request, chatMessage) => chatMessage.ToQueryResponseWithoutChat()));
		}
	}
}
