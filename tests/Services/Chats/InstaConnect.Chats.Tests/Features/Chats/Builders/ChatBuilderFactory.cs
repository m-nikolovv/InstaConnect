namespace InstaConnect.Chats.Tests.Features.Chats.Builders;

public class ChatBuilderFactory
{
	public ChatBuilder Create(User participantOne, User participantTwo)
	{
		return new(participantOne, participantTwo);
	}

	public ChatBuilder Create(Chat chat)
	{
		return new(chat);
	}
}
