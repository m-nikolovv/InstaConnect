namespace InstaConnect.Chats.Domain.Features.ChatMessageImages.Extensions;

public static class ChatMessageImageCollectionExtensions
{
	extension(ICollection<ChatMessageImage> chatMessageImages)
	{
		public ICollection<ChatMessageImage> AddChatMessage(ChatMessage chatMessage)
		{
			foreach (var chatMessageImage in chatMessageImages)
			{
				chatMessageImage.AddChatMessage(chatMessage);
			}

			return chatMessageImages;
		}
	}
}
