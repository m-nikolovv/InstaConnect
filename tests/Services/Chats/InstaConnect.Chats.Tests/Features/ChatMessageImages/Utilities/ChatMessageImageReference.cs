using InstaConnect.Chats.Domain.Features.ChatMessageImages.Extensions;

namespace InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

public static class ChatMessageImageReference
{
	extension(ICollection<ChatMessage> chatMessages)
	{
		public ICollection<ChatMessage> SetChatMessageImages()
		{
			foreach (var chatMessage in chatMessages)
			{
				chatMessage.SetChatMessageImages();
			}

			return chatMessages;
		}
	}

	extension(ChatMessage? chatMessage)
	{
		public ChatMessage? SetChatMessageImages()
		{
			chatMessage?.ChatMessageImages.AddChatMessage(chatMessage);

			return chatMessage;
		}
	}
}
