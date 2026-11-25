using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Responses;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageInfrastructureMatcher
{
	extension(ChatMessage chatMessage)
	{
		public ChatMessageResponse IsChatMessageResponse(CurrentUserQuery currentUserQuery)
		{
			return Matcher.Is<ChatMessageResponse>(p => p.Matches(chatMessage.Id, currentUserQuery, chatMessage));
		}
	}
}
