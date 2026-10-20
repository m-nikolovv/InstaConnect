using InstaConnect.Chats.Domain.Features.ChatMessages.Extensions;

namespace InstaConnect.Chats.Tests.Features.Users.Utilities;

public static class UserReference
{
	extension(User? user)
	{
		public User? SetChats()
		{
			user?.Chats.SetParticipantOne().SetParticipantTwo();

			return user;
		}

		public User? SetChatMessages()
		{
			user?.ChatMessages.AddSender(user).SetChat();

			return user;
		}
	}
}
