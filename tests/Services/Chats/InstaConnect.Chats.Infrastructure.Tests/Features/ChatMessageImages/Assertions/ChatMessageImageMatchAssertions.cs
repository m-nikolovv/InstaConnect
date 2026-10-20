using InstaConnect.Chats.Domain.Features.ChatMessageImages.Models.ValueObjects;
using InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessageImages.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessageImages.Assertions;

public static class ChatMessageImageMatchAssertions
{
	extension(ChatMessageImage response)
	{
		public void ShouldSatisfy(ChatMessageImageId id, ChatMessageImage chatMessageImage)
		{
			response.ShouldSatisfy(p => p.Matches(id, chatMessageImage));
		}
	}

	extension(ICollection<ChatMessageImage> response)
	{
		public void ShouldSatisfy(ICollection<ChatMessageImageId> ids, ICollection<ChatMessageImage> chatMessageImages)
		{
			response.ShouldSatisfy(p => p.Matches(ids, chatMessageImages));
		}
	}
}
