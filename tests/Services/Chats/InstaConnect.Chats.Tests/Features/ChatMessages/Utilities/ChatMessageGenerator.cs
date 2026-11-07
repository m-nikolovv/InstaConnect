namespace InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageGenerator
{
	extension(ChatMessage baseChatMessage)
	{
		public ICollection<ChatMessage> GenerateAttached(IEnumerable<Chat> chats, int numberOfIterations = 3)
		{
			var chatMessages = baseChatMessage.Generate(chats, numberOfIterations);

			foreach (var chatMessage in chatMessages.Where(c => c != baseChatMessage))
			{
				chatMessage.Sender!.AddChatMessage(chatMessage);
				chatMessage.Chat!.AddChatMessage(chatMessage);
			}

			return chatMessages;
		}

		public ICollection<ChatMessage> Generate(IEnumerable<Chat> chats, int numberOfIterations = 3)
		{
			return [baseChatMessage, ..chats.SelectMany(chat =>
				 Enumerable.Range(default, numberOfIterations).Select(_ =>
				 {
					 var chatMessage = new ChatMessage(
						 new(chat.Id, ChatMessageDataFaker.GetId()),
						 chat.Id.ParticipantOneId,
						 ChatMessageDataFaker.GetContent(),
						 new(ChatMessageDataFaker.GetSummary()),
						 ChatMessageDataFaker.GetCreatedAtUtc(),
						 ChatMessageDataFaker.GetUpdatedAtUtc()
					 );

					 chatMessage.AddSender(chat.ParticipantOne);
					 chatMessage.AddChat(chat);

					 return chatMessage;
				 })),
				 ..chats.SelectMany(chat =>
				 Enumerable.Range(default, numberOfIterations).Select(_ =>
				 {
					 var chatMessage = new ChatMessage(
						 new(chat.Id, ChatMessageDataFaker.GetId()),
						 chat.Id.ParticipantTwoId,
						 ChatMessageDataFaker.GetContent(),
						 new(ChatMessageDataFaker.GetSummary()),
						 ChatMessageDataFaker.GetCreatedAtUtc(),
						 ChatMessageDataFaker.GetUpdatedAtUtc()
					 );

					 chatMessage.AddSender(chat.ParticipantTwo);
					 chatMessage.AddChat(chat);

					 return chatMessage;
				 }))];
		}
	}
}
