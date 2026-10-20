namespace InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageMapper
{
	extension(ChatMessage chatMessage)
	{
		public ChatMessageId ToId()
		{
			return chatMessage.Id;
		}
	}
}
