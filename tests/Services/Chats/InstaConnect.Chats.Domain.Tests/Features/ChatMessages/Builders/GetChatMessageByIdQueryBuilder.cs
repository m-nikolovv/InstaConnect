namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Builders;

public class GetChatMessageByIdQueryBuilder
{
	private string _participantTwoId;
	private string _messageId;
	private string _currentUserId;

	public GetChatMessageByIdQueryBuilder(ChatMessage chatMessage, UserId currentUserId)
	{
		_participantTwoId = chatMessage.Id.Id.ParticipantTwoId.Id;
		_messageId = chatMessage.Id.MessageId;
		_currentUserId = currentUserId.Id;
	}

	public GetChatMessageByIdQueryBuilder WithParticipantTwoId(UserId participantTwoId, IStringTransformer? transformer = null)
	{
		_participantTwoId = transformer.TryTransform(participantTwoId.Id);

		return this;
	}

	public GetChatMessageByIdQueryBuilder WithParticipantTwoId(IStringTransformer transformer)
	{
		_participantTwoId = transformer.Transform(_participantTwoId);

		return this;
	}

	public GetChatMessageByIdQueryBuilder WithMessageId(ChatMessageId messageId, IStringTransformer? transformer = null)
	{
		_messageId = transformer.TryTransform(messageId.MessageId);

		return this;
	}

	public GetChatMessageByIdQueryBuilder WithMessageId(IStringTransformer transformer)
	{
		_messageId = transformer.Transform(_messageId);

		return this;
	}

	public GetChatMessageByIdQueryBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetChatMessageByIdQueryBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetChatMessageByIdQuery Build()
	{
		return new(
			new(
				new(
					new(_currentUserId),
					new(_participantTwoId)),
				_messageId),
			new(
				new(_currentUserId)));
	}
}
