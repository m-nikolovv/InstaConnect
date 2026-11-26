using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.Responses;

namespace InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

public static class ChatMessageImageMapper
{
	extension(ChatMessageImage chatMessageImage)
	{
		public ChatMessageImageResponse ToFullResponse()
		{
			return new(
				chatMessageImage.Id,
				chatMessageImage.Url,
				chatMessageImage.CreatedAtUtc);
		}
	}

	extension(ICollection<ChatMessageImage> chatMessageImages)
	{
		public ICollection<ChatMessageImageResponse> ToFullResponse()
		{
			return [.. chatMessageImages.Select(chatMessageImage => chatMessageImage.ToFullResponse())];
		}
	}
}
