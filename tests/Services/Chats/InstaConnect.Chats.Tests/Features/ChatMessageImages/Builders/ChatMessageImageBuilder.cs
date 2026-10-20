using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;

namespace InstaConnect.Chats.Tests.Features.ChatMessageImages.Builders;

public class ChatMessageImageBuilder
{
	private readonly string _url;
	private readonly string _imageId;
	private readonly string _messageId;
	private readonly string _participantOneId;
	private readonly string _participantTwoId;
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

		_chatMessage.AddChatMessageImage(chatMessageImage);
		chatMessageImage.AddChatMessage(_chatMessage);

		return chatMessageImage;
	}
}
