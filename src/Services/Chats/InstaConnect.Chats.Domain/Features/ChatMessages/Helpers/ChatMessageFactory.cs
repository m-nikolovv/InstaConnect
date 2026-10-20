using InstaConnect.Common.Domain.Features.Guids.Abstractions;

namespace InstaConnect.Chats.Domain.Features.ChatMessages.Helpers;

internal class ChatMessageFactory : IChatMessageFactory
{
	private readonly IGuidProvider _guidProvider;
	private readonly IDateTimeProvider _dateTimeProvider;

	public ChatMessageFactory(
		IGuidProvider guidProvider,
		IDateTimeProvider dateTimeProvider)
	{
		_guidProvider = guidProvider;
		_dateTimeProvider = dateTimeProvider;
	}

	public ChatMessage Create(ChatId id, UserId senderId, string content)
	{
		var messageId = _guidProvider.NewStringGuid();
		var utcNow = _dateTimeProvider.GetOffsetUtcNow();
		var chatMessage = new ChatMessage(
			new(id, messageId),
			senderId,
			content,
			new(string.Empty),
			utcNow,
			utcNow);

		return chatMessage;
	}
}
