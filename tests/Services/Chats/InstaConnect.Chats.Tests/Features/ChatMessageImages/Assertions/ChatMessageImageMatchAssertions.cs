using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.Assertions;

namespace InstaConnect.Chats.Tests.Features.ChatMessageImages.Assertions;

public static class ChatMessageImageMatchAssertions
{
	extension(ICollection<ChatMessageImage> p)
	{
		public void ShouldSatisfy(ICollection<ChatMessageImage> chatMessageImages)
		{
			p.ShouldSatisfy(u => u.Matches(chatMessageImages));
		}
	}

	extension(ChatMessageImage p)
	{
		public void ShouldSatisfy(ChatMessageImage chatMessageImage)
		{
			p.ShouldSatisfy(u => u.Matches(chatMessageImage));
		}
	}
}
