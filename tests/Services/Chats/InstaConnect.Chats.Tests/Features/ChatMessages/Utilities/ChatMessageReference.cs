namespace InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageReference
{
	extension(ICollection<ChatMessage> chatMessages)
	{
		public ICollection<ChatMessage> SetSender()
		{
			foreach (var chatMessage in chatMessages)
			{
				chatMessage.SetSender();
			}

			return chatMessages;
		}

		public ICollection<ChatMessage> SetChat()
		{
			foreach (var chatMessage in chatMessages)
			{
				chatMessage.SetChat();
			}

			return chatMessages;
		}
	}

	extension(ChatMessage? chatMessage)
	{
		public ChatMessage? SetSender()
		{
			chatMessage?.Sender?.AddChatMessage(chatMessage);

			return chatMessage;
		}

		public ChatMessage? SetChat()
		{
			chatMessage?.Chat?.AddChatMessage(chatMessage);
			chatMessage?.Chat?.SetParticipantOne().SetParticipantTwo();

			return chatMessage;
		}
	}
}
