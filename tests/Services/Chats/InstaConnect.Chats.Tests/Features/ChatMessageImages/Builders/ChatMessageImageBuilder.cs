using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.Base;

namespace InstaConnect.Chats.Tests.Features.ChatMessageImages.Builders;

public class ChatMessageImageBuilder
{
	private readonly string _url;
	private string _imageId;
	private string _messageId;
	private string _participantOneId;
	private string _participantTwoId;
	private readonly ChatMessage _chatMessage;
	private readonly DateTimeOffset _createdAtUtc;

	public ChatMessageImageBuilder(ChatMessage chatMessage)
	{
		_url = ChatMessageImageDataFaker.GetUrl();
		_imageId = ChatMessageImageDataFaker.GetImageId();
		_messageId = chatMessage.Id.MessageId;
		_participantOneId = chatMessage.Id.Id.ParticipantOneId.Id;
		_participantTwoId = chatMessage.Id.Id.ParticipantTwoId.Id;
		_chatMessage = chatMessage;
		_createdAtUtc = ChatMessageImageDataFaker.GetCreatedAtUtc();
	}

	public ChatMessageImageBuilder(ChatMessageImage chatMessageImage)
	{
		_url = chatMessageImage.Url.Value;
		_imageId = chatMessageImage.Id.ImageId;
		_messageId = chatMessageImage.Id.Id.MessageId;
		_participantOneId = chatMessageImage.Id.Id.Id.ParticipantOneId.Id;
		_participantTwoId = chatMessageImage.Id.Id.Id.ParticipantTwoId.Id;
		_chatMessage = chatMessageImage.ChatMessage!;
		_createdAtUtc = chatMessageImage.CreatedAtUtc;
	}

	public ChatMessageImageBuilder WithParticipantOneId(IStringTransformer transformer)
	{
		_participantOneId = transformer.Transform(_participantOneId);

		return this;
	}

	public ChatMessageImageBuilder WithParticipantTwoId(IStringTransformer transformer)
	{
		_participantTwoId = transformer.Transform(_participantTwoId);

		return this;
	}

	public ChatMessageImageBuilder WithMessageId(IStringTransformer transformer)
	{
		_messageId = transformer.Transform(_messageId);

		return this;
	}

	public ChatMessageImageBuilder WithImageId(ChatMessageImageId imageId, IStringTransformer? transformer = null)
	{
		_imageId = transformer.TryTransform(imageId.ImageId);

		return this;
	}

	public ChatMessageImageBuilder WithImageId(IStringTransformer transformer)
	{
		_imageId = transformer.Transform(_imageId);

		return this;
	}

	public ChatMessageImage BuildAttached()
	{
		var chatMessageImage = Build();

		_chatMessage.AddChatMessageImage(chatMessageImage);

		return chatMessageImage;
	}

	public ChatMessageImage Build()
	{
		var chatMessageImage = new ChatMessageImage(
				new(
					new(
						new(
							new(_participantOneId),
							new(_participantTwoId)),
						_messageId),
					_imageId),
				new(_url),
				_createdAtUtc);

		chatMessageImage.AddChatMessage(_chatMessage);

		return chatMessageImage;
	}
}
