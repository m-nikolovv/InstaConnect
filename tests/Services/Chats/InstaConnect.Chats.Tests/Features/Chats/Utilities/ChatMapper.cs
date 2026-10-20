namespace InstaConnect.Chats.Tests.Features.Chats.Utilities;

public static class ChatMapper
{
	extension(Chat chat)
	{
		public ChatId ToId()
		{
			return chat.Id;
		}
	}
}
