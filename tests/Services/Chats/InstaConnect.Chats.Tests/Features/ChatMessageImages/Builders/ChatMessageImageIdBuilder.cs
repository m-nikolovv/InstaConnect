namespace InstaConnect.Chats.Tests.Features.ChatMessageImages.Builders;

public class ChatMessageImageIdBuilder
{
	private string _imageId;
	private string _messageId;
	private string _participantOneId;
	private string _participantTwoId;

	public ChatMessageImageIdBuilder(ChatMessageImageId id)
	{
		_imageId = id.ImageId;
		_messageId = id.Id.MessageId;
		_participantOneId = id.Id.Id.ParticipantOneId.Id;
		_participantTwoId = id.Id.Id.ParticipantTwoId.Id;
	}

	public ChatMessageImageIdBuilder WithParticipantOneId(IStringTransformer transformer)
	{
		_participantOneId = transformer.Transform(_participantOneId);

		return this;
	}

	public ChatMessageImageIdBuilder WithParticipantTwoId(IStringTransformer transformer)
	{
		_participantTwoId = transformer.Transform(_participantTwoId);

		return this;
	}

	public ChatMessageImageIdBuilder WithMessageId(IStringTransformer transformer)
	{
		_messageId = transformer.Transform(_messageId);

		return this;
	}

	public ChatMessageImageIdBuilder WithImageId(IStringTransformer transformer)
	{
		_imageId = transformer.Transform(_imageId);

		return this;
	}

	public ChatMessageImageId Build()
	{
		return new(
			new(
				new(
					new(_participantOneId),
					new(_participantTwoId)),
				_messageId),
			_imageId);
	}
}
