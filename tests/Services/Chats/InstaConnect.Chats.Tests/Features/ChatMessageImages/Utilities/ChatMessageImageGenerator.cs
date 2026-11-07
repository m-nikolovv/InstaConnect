namespace InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

public static class ChatMessageImageGenerator
{
	extension(ChatMessageImage baseChatMessageImage)
	{
		public ICollection<ChatMessageImage> GenerateAttached(IEnumerable<ChatMessage> chatMessages)
		{
			var chatMessageImages = baseChatMessageImage.Generate(chatMessages);

			foreach (var chatMessageImage in chatMessageImages.Where(c => c != baseChatMessageImage))
			{
				chatMessageImage.ChatMessage!.AddChatMessageImage(chatMessageImage);
			}

			return chatMessageImages;
		}

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

						chatMessageImage.AddChatMessage(chatMessage);

						return chatMessageImage;
					}))];
		}
	}
}
