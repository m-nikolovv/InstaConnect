using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Utilities;
using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Helpers.Caches;

internal class ChatMessageImageCacheHandler : IChatMessageImageCacheHandler
{
	private readonly ICacheHandler _cacheHandler;

	public ChatMessageImageCacheHandler(ICacheHandler cacheHandler)
	{
		_cacheHandler = cacheHandler;
	}

	public async Task DeleteAsync(ChatMessageImageId id, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagAsync(ChatMessageImageCacheUtilities.GetTag(id), cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<ChatMessageImageId> ids, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagRangeAsync(ChatMessageImageCacheUtilities.GetTagRange(ids), cancellationToken);
	}
}
