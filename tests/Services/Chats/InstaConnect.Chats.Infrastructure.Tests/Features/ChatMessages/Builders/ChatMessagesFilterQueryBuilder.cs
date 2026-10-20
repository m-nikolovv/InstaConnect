namespace InstaConnect.Chats.Infrastructure.Tests.Features.ChatMessages.Builders;

public class ChatMessagesFilterQueryBuilder
{
	private string _participantOneId;
	private string _participantTwoId;

	public ChatMessagesFilterQueryBuilder(ChatMessage chatMessage)
	{
		_participantOneId = chatMessage.Id.Id.ParticipantOneId.Id;
		_participantTwoId = chatMessage.Id.Id.ParticipantTwoId.Id;
	}

	public ChatMessagesFilterQueryBuilder WithParticipantOneId(UserId participantOneId, IStringTransformer? transformer = null)
	{
		_participantOneId = transformer.TryTransform(participantOneId.Id);

		return this;
	}

	public ChatMessagesFilterQueryBuilder WithParticipantOneId(IStringTransformer transformer)
	{
		_participantOneId = transformer.Transform(_participantOneId);

		return this;
	}

	public ChatMessagesFilterQueryBuilder WithParticipantTwoId(UserId participantTwoId, IStringTransformer? transformer = null)
	{
		_participantTwoId = transformer.TryTransform(participantTwoId.Id);

		return this;
	}

	public ChatMessagesFilterQueryBuilder WithParticipantTwoId(IStringTransformer transformer)
	{
		_participantTwoId = transformer.Transform(_participantTwoId);

		return this;
	}

	public ChatMessagesFilterQuery Build()
	{
		return new(
			new(
				new(_participantOneId),
				new(_participantTwoId)));
	}
}
