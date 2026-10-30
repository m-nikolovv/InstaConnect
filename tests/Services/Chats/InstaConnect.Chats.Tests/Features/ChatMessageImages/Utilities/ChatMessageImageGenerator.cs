namespace InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

public static class ChatMessageImageGenerator
{
	extension(ChatMessageImage baseChatMessageImage)
	{
		public ICollection<ChatMessageImage> Generate(IEnumerable<ChatMessage> chatMessages)
		{
			return [baseChatMessageImage, .. chatMessages
				.SelectMany(chatMessage =>
					Enumerable.Range(default, DataFaker.GetAverageNumber(ChatMessageConfigurations.ImagesMaxCount) - chatMessage.ChatMessageImages.Count).Select(_ =>
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
