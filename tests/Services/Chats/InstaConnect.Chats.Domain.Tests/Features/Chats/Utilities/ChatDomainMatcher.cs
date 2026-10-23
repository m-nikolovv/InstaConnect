using InstaConnect.Chats.Events.Features.Chats.Models;

namespace InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;

public static class ChatDomainMatcher
{
	extension(AddChatCommand command)
	{
		public Chat IsChat()
		{
			return Matcher.Is<Chat>(p => p.Matches(command));
		}

		public ChatAddedEventRequest IsChatAddedEventRequest(Chat chat)
		{
			return Matcher.Is<ChatAddedEventRequest>(p => p.Matches(command, chat));
		}
	}
}
