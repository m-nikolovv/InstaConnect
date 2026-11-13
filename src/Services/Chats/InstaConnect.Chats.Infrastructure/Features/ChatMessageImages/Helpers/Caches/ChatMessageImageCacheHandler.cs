using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Models.Options;
using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Utilities;
using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Helpers.Caches;

internal class ChatMessageImageCacheHandler : IChatMessageImageCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly ChatMessageImageCacheOptions _cacheOptions;

	public ChatMessageImageCacheHandler(ICacheHandler cacheHandler, ChatMessageImageCacheOptions cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions;
	}

	public async Task<ChatMessageImage?> GetByIdAsync(ChatMessageImageId id, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<ChatMessageImage>(ChatMessageImageCacheUtilities.GetByIdKey(id), cancellationToken);
	}

	public async Task AddAsync(ChatMessageImage entity, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			ChatMessageImageCacheUtilities.GetByIdKey(entity.Id),
			entity,
			_cacheOptions.Expirations[ChatMessageImageCacheUtilities.GetByIdKeyPrefix],
			[ChatMessageImageCacheUtilities.GetTag(entity.Id),
			 ChatMessageCacheUtilities.GetResponseTag(entity.Id.Id)],
			[ChatMessageCacheUtilities.GetTag(entity.Id.Id)],
			cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<ChatMessageImage> entities, CancellationToken cancellationToken)
	{
		foreach (var entity in entities)
		{
			await AddAsync(entity, cancellationToken);
		}
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
