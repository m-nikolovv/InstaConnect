using InstaConnect.Chats.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Chats.Tests.Features.Chats.Assertions;
using InstaConnect.Chats.Tests.Features.Users.Assertions;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageMatchAssertions
{
	extension(ICollection<ChatMessage> p)
	{
		public void ShouldSatisfy(ICollection<ChatMessage> chatMessages)
		{
			p.ShouldSatisfy(u => u.Matches(chatMessages));
		}
	}

	extension(ChatMessage u)
	{
		public void ShouldSatisfy(ChatMessage chatMessage)
		{
			u.ShouldSatisfy(u => u.Matches(chatMessage));
		}
	}
}
