using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.ValueObjects;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessageImages.Utilities;

public static class ChatMessageImageEquals
{
	extension(ChatMessageImage p)
	{
		public bool Matches(
			ChatMessageImageId id,
			ChatMessageImage chatMessageImage)
		{
			return p.Matches(chatMessageImage);
		}
	}

	extension(ICollection<ChatMessageImage> p)
	{
		public bool Matches(
			ICollection<ChatMessageImageId> ids,
			ICollection<ChatMessageImage> chatMessageImages)
		{
			return p.Matches(chatMessageImages);
		}
	}
}
