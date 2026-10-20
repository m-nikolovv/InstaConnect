using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Responses;
using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Utilities;

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
	}

	extension(ICollection<ChatMessage> chatMessages)
	{
		public ICollection<ChatMessageResponse> ToResponse(
			ChatMessagesFilterQuery filterQuery,
			ChatMessagesPaginationQuery paginationQuery)
		{
			return chatMessages.Filter(paginationQuery, chatMessage => chatMessage.MatchesFilter(filterQuery), chatMessage => chatMessage.ToResponseWithoutChat());
		}

		public long ToTotalCountResponse(
			ChatMessagesFilterQuery filterQuery)
		{
			return chatMessages.Count(chatMessage => chatMessage.MatchesFilter(filterQuery));
		}
	}
}
