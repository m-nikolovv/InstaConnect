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
