namespace InstaConnect.Chats.Infrastructure.Tests.Features.Chats.Builders;

public class ChatsFilterQueryBuilder
{
	private string _participantOneId;
	private string _participantTwoName;

	public ChatsFilterQueryBuilder(Chat chat)
	{
		_participantOneId = chat.Id.ParticipantOneId.Id;
		_participantTwoName = DataFaker.GetPrefixString(chat.ParticipantTwo!.Name.Value);
	}

	public ChatsFilterQueryBuilder WithParticipantOneId(UserId participantOneId, IStringTransformer? transformer = null)
	{
		_participantOneId = transformer.TryTransform(participantOneId.Id);

		return this;
	}

	public ChatsFilterQueryBuilder WithParticipantOneId(IStringTransformer transformer)
	{
		_participantOneId = transformer.Transform(_participantOneId);

		return this;
	}

	public ChatsFilterQueryBuilder WithParticipantTwoName(Name participantTwoName, IStringTransformer? transformer = null)
	{
		_participantTwoName = transformer.TryTransform(participantTwoName.Value);

		return this;
	}

	public ChatsFilterQueryBuilder WithParticipantTwoName(IStringTransformer transformer)
	{
		_participantTwoName = transformer.Transform(_participantTwoName);

		return this;
	}

	public ChatsFilterQuery Build()
	{
		return new(new(_participantOneId), new(_participantTwoName));
	}
}
