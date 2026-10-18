using InstaConnect.Chats.Application.Features.Users.Abstractions;
using InstaConnect.Chats.Application.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Application.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Application.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Application.Tests.Features.Users.Utilities;
using InstaConnect.Common.Application.Features.Requests.Abstractions;

namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageMapper
{
	extension(ChatMessage chatMessage)
	{
		internal ChatMessageResponse ToFullResponse()
		{
			return new(chatMessage.Id,
					   chatMessage.Content,
					   chatMessage.Summary,
					   chatMessage.SenderId,
					   chatMessage.Chat?.ToFullResponse(),
					   chatMessage.Sender?.ToFullResponse(),
					   chatMessage.ChatMessageImages.ToFullResponse(),
					   chatMessage.CreatedAtUtc,
					   chatMessage.UpdatedAtUtc);
		}

		internal ChatMessageResponse ToResponseWithoutSender()
		{
			return new(chatMessage.Id,
					   chatMessage.Content,
					   chatMessage.Summary,
					   chatMessage.SenderId,
					   chatMessage.Chat?.ToFullResponse(),
					   null,
					   chatMessage.ChatMessageImages.ToFullResponse(),
					   chatMessage.CreatedAtUtc,
					   chatMessage.UpdatedAtUtc);
		}

		internal ChatMessageResponse ToResponseWithoutChat()
		{
			return new(chatMessage.Id,
					   chatMessage.Content,
					   chatMessage.Summary,
					   chatMessage.SenderId,
					   null,
					   chatMessage.Sender?.ToFullResponse(),
					   chatMessage.ChatMessageImages.ToFullResponse(),
					   chatMessage.CreatedAtUtc,
					   chatMessage.UpdatedAtUtc);
		}

		public ChatMessageId ToResponse(
			AddChatMessageCommandRequest request)
		{
			return chatMessage.ToId();
		}

		public ChatMessageId ToResponse(
			UpdateChatMessageCommandRequest request)
		{
			return chatMessage.ToId();
		}

		public ChatMessageResponse ToResponse(
			GetChatMessageByIdQueryRequest request)
		{
			return chatMessage.ToFullResponse();
		}
	}

	extension(ICollection<ChatMessage> chatMessages)
	{
		internal ChatMessageCollectionResponse ToResponseWithoutSender<TRequest>(
		TRequest request,
		Chat chat,
		Func<TRequest, ChatMessage, bool> filter,
		Func<TRequest, ChatMessage, ChatMessageResponse> transform)
		where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var totalCount = chatMessages.Count(chatMessage => filter(request, chatMessage));

			return new(chat.ToFullResponse(),
					   null,
					   chatMessages.Filter(request, chatMessage => filter(request, chatMessage), chatMessage => transform(request, chatMessage)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		internal ChatMessageCollectionResponse ToResponseWithoutChat<TRequest>(
			TRequest request,
			User user,
			Func<TRequest, ChatMessage, bool> filter,
			Func<TRequest, ChatMessage, ChatMessageResponse> transform)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var totalCount = chatMessages.Count(chatMessage => filter(request, chatMessage));

			return new(null,
					   user.ToFullResponse(),
					   chatMessages.Filter(request, chatMessage => filter(request, chatMessage), chatMessage => transform(request, chatMessage)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		public ChatMessageCollectionResponse ToResponse(
			GetAllChatMessagesQueryRequest request,
			Chat chat)
		{
			return chatMessages.ToResponseWithoutSender(
													  request,
													  chat,
													  (request, chatMessage) => chatMessage.MatchesFilter(request),
													  (request, chatMessage) => chatMessage.ToResponseWithoutChat());
		}
	}
}
