using InstaConnect.Chats.Domain.Features.ChatMessageImages.Abstractions;
using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;

namespace InstaConnect.Chats.Domain.Features.ChatMessageImages.Helpers;

internal class ChatMessageImageFactory : IChatMessageImageFactory
{
	private readonly IGuidProvider _guidProvider;
	private readonly IDateTimeProvider _dateTimeProvider;

	public ChatMessageImageFactory(
		IGuidProvider guidProvider,
		IDateTimeProvider dateTimeProvider)
	{
		_guidProvider = guidProvider;
		_dateTimeProvider = dateTimeProvider;
	}

	public ICollection<ChatMessageImage> CreateRange(ChatMessageId id, ICollection<Url> urls)
	{
		var utcNow = _dateTimeProvider.GetOffsetUtcNow();
		var chatMessageImages = urls
			.Select(url => new ChatMessageImage(
				new(id, _guidProvider.NewStringGuid()),
				url,
				utcNow))
			.ToList();

		return chatMessageImages;
	}
}
