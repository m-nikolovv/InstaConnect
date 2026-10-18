namespace InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

public static class ChatMessageImageGenerator
{
	extension(ChatMessageImage baseChatMessageImage)
	{
		public ICollection<ChatMessageImage> Generate(IEnumerable<ChatMessage> chatMessages, int numberOfIterations = 5)
		{
			return [baseChatMessageImage, .. chatMessages
				.SelectMany(chatMessage =>
					Enumerable.Range(default, numberOfIterations).Select(_ =>
					{
						var chatMessageImage = new ChatMessageImage(
							new(chatMessage.Id, ChatMessageImageDataFaker.GetImageId()),
							new(ChatMessageImageDataFaker.GetUrl()),
							ChatMessageImageDataFaker.GetCreatedAtUtc());

						chatMessage.AddChatMessageImage(chatMessageImage);
						chatMessageImage.AddChatMessage(chatMessage);

						return chatMessageImage;
					}))];
		}
	}
}
