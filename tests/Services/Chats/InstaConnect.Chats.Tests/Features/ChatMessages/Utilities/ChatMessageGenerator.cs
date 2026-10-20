namespace InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageGenerator
{
	extension(ChatMessage baseChatMessage)
	{
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
					 chat.ParticipantOne!.AddChatMessage(chatMessage);
					 chat.AddChatMessage(chatMessage);

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
					 chat.ParticipantTwo!.AddChatMessage(chatMessage);
					 chat.AddChatMessage(chatMessage);

					 return chatMessage;
				 }))];
		}
	}
}
