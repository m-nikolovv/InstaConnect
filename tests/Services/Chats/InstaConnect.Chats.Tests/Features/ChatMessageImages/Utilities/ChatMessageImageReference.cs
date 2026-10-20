using InstaConnect.Chats.Domain.Features.ChatMessageImages.Extensions;

namespace InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

public static class ChatMessageImageReference
{
	extension(ChatMessage? chatMessage)
	{
		public ChatMessage? SetChatMessageImages()
		{
			chatMessage?.ChatMessageImages.AddChatMessage(chatMessage);

			return chatMessage;
		}
	}
}
