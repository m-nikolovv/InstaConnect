using InstaConnect.Common.Tests.Features.DataAttributes.Base;

namespace InstaConnect.Chats.Tests.Features.Chats.Builders;

public class ChatIdBuilder
{
	private string _participantOneId;
	private string _participantTwoId;

	public ChatIdBuilder(ChatId id)
	{
		_participantOneId = id.ParticipantOneId.Id;
		_participantTwoId = id.ParticipantTwoId.Id;
	}

	public ChatIdBuilder WithParticipantOneId(UserId participantOneId, IStringTransformer? transformer = null)
	{
		_participantOneId = transformer.TryTransform(participantOneId.Id);

		return this;
	}

	public ChatIdBuilder WithParticipantOneId(IStringTransformer transformer)
	{
		_participantOneId = transformer.Transform(_participantOneId);

		return this;
	}

	public ChatIdBuilder WithParticipantTwoId(UserId participantTwoId, IStringTransformer? transformer = null)
	{
		_participantTwoId = transformer.TryTransform(participantTwoId.Id);

		return this;
	}

	public ChatIdBuilder WithParticipantTwoId(IStringTransformer transformer)
	{
		_participantTwoId = transformer.Transform(_participantTwoId);

		return this;
	}

	public ChatId Build()
	{
		return new(
			new(_participantOneId),
			new(_participantTwoId));
	}
}
