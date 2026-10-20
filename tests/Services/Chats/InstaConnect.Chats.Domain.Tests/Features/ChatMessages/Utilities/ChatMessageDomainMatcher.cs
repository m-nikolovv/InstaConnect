namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageDomainMatcher
{
	extension(AddChatMessageCommand command)
	{
		public ChatMessage IsChatMessage()
		{
			return Matcher.Is<ChatMessage>(p => p.Matches(command));
		}

		public ChatMessageAddedNotificationRequest IsChatMessageAddedNotificationRequest(ChatMessage chatMessage)
		{
			return Matcher.Is<ChatMessageAddedNotificationRequest>(p => p.Matches(command, chatMessage));
		}

		public ICollection<Url> IsImages()
		{
			return Matcher.Is<ICollection<Url>>(p => p.Matches(command));
		}

		public ICollection<ChatMessageImage> IsChatMessageImages()
		{
			return Matcher.Is<ICollection<ChatMessageImage>>(p => p.Matches(command));
		}
	}

	extension(UpdateChatMessageCommand command)
	{
		public ChatMessage IsChatMessage()
		{
			return Matcher.Is<ChatMessage>(p => p.Matches(command));
		}

		public ChatMessageUpdatedNotificationRequest IsChatMessageUpdatedNotificationRequest(ChatMessage chatMessage)
		{
			return Matcher.Is<ChatMessageUpdatedNotificationRequest>(p => p.Matches(command, chatMessage));
		}
	}

	extension(DeleteChatMessageCommand command)
	{
		public ChatMessage IsChatMessage()
		{
			return Matcher.Is<ChatMessage>(p => p.Matches(command));
		}

		public ChatMessageDeletedNotificationRequest IsChatMessageDeletedNotificationRequest(ChatMessage chatMessage)
		{
			return Matcher.Is<ChatMessageDeletedNotificationRequest>(p => p.Matches(command, chatMessage));
		}
	}
}
