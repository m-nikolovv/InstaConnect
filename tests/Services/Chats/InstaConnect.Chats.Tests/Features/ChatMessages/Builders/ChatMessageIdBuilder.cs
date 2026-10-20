using InstaConnect.Common.Tests.Features.DataAttributes.Base;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Builders;

public class ChatMessageIdBuilder
{
	private string _participantOneId;
	private string _participantTwoId;
	private string _messageId;

	public ChatMessageIdBuilder(ChatMessageId id)
	{
		_participantOneId = id.Id.ParticipantOneId.Id;
		_participantTwoId = id.Id.ParticipantTwoId.Id;
		_messageId = id.MessageId;
	}

	public ChatMessageIdBuilder WithParticipantOneId(UserId participantOneId, IStringTransformer? transformer = null)
	{
		_participantOneId = transformer.TryTransform(participantOneId.Id);

		return this;
	}

	public ChatMessageIdBuilder WithParticipantOneId(IStringTransformer transformer)
	{
		_participantOneId = transformer.Transform(_participantOneId);

		return this;
	}

	public ChatMessageIdBuilder WithParticipantTwoId(UserId participantTwoId, IStringTransformer? transformer = null)
	{
		_participantTwoId = transformer.TryTransform(participantTwoId.Id);

		return this;
	}

	public ChatMessageIdBuilder WithParticipantTwoId(IStringTransformer transformer)
	{
		_participantTwoId = transformer.Transform(_participantTwoId);

		return this;
	}

	public ChatMessageIdBuilder WithMessageId(IStringTransformer transformer)
	{
		_messageId = transformer.Transform(_messageId);

		return this;
	}

	public ChatMessageId Build()
	{
		return new(
			new(
				new(_participantOneId),
				new(_participantTwoId)),
			_messageId);
	}
}
