using InstaConnect.Chats.Domain.Features.Chats.Models.Responses;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Utilities;

public static class ChatInfrastructureMatcher
{
	extension(Chat chat)
	{
		public ChatResponse IsChatResponse(CurrentUserQuery currentUserQuery)
		{
			return Matcher.Is<ChatResponse>(p => p.Matches(chat.Id, currentUserQuery, chat));
		}
	}
}
