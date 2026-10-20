namespace InstaConnect.Chats.Domain.Features.Chats.Helpers;

internal class ChatFactory : IChatFactory
{
	private readonly IDateTimeProvider _dateTimeProvider;

	public ChatFactory(IDateTimeProvider dateTimeProvider)
	{
		_dateTimeProvider = dateTimeProvider;
	}

	public Chat Create(UserId participantOneId, UserId participantTwoId)
	{
		var utcNow = _dateTimeProvider.GetOffsetUtcNow();
		var chat = new Chat(
			new(participantOneId, participantTwoId),
			utcNow);

		return chat;
	}
}
