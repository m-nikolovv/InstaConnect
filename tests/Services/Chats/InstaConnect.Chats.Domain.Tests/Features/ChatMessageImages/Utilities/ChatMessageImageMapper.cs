using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.Responses;

namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessageImages.Utilities;

public static class ChatMessageImageMapper
{
	extension(ChatMessageImage chatMessageImage)
	{
		internal ChatMessageImageResponse ToFullResponse()
		{
			return new(
				chatMessageImage.Id,
				chatMessageImage.Url,
				chatMessageImage.CreatedAtUtc);
		}
	}

	extension(ICollection<ChatMessageImage> chatMessageImages)
	{
		internal ICollection<ChatMessageImageResponse> ToFullResponse()
		{
			return [.. chatMessageImages.Select(chatMessageImage => chatMessageImage.ToFullResponse())];
		}
	}
}
