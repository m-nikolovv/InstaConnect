using InstaConnect.Chats.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Chats.Tests.Features.Chats.Assertions;
using InstaConnect.Chats.Tests.Features.Users.Assertions;

namespace InstaConnect.Chats.Tests.Features.Chats.Assertions;

public static class ChatMatchAssertions
{
	extension(ICollection<Chat> p)
	{
		public void ShouldSatisfy(ICollection<Chat> chats)
		{
			p.ShouldSatisfy(u => u.Matches(chats));
		}
	}

	extension(Chat u)
	{
		public void ShouldSatisfy(Chat chat)
		{
			u.ShouldSatisfy(u => u.Matches(chat));
		}
	}
}
