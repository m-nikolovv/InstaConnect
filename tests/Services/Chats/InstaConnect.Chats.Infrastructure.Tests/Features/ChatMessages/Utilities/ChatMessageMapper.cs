using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Responses;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageMapper
{
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
