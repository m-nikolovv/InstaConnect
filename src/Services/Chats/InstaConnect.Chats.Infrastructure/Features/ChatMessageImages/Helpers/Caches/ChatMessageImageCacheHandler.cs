using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Models.Options;
using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Utilities;
using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Infrastructure.Features.Chats.Utilities;
using InstaConnect.Chats.Infrastructure.Features.Users.Utilities;
using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;

using Microsoft.Extensions.Options;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Helpers.Caches;

internal class ChatMessageImageCacheHandler : IChatMessageImageCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly ChatMessageImageCacheOptions _cacheOptions;

	public ChatMessageImageCacheHandler(ICacheHandler cacheHandler, IOptions<ChatMessageImageCacheOptions> cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions.Value;
	}

	public async Task<ChatMessageImage?> GetByIdAsync(ChatMessageImageId id)
	{
		return await _cacheHandler.GetAsync<ChatMessageImage>(ChatMessageImageCacheUtilities.GetByIdKey(id));
	}

	public async Task AddAsync(ChatMessageImage entity)
	{
		await _cacheHandler.SetAsync(
			ChatMessageImageCacheUtilities.GetByIdKey(entity.Id),
			entity,
			_cacheOptions.Expirations[ChatMessageImageCacheUtilities.GetByIdKeyPrefix],
			[ChatMessageImageCacheUtilities.GetTag(entity.Id),
			 ChatMessageCacheUtilities.GetTag(entity.Id.Id),
			 ChatCacheUtilities.GetTag(entity.Id.Id.Id),
			 UserCacheUtilities.GetTag(entity.Id.Id.Id.ParticipantOneId),
			 UserCacheUtilities.GetTag(entity.Id.Id.Id.ParticipantTwoId)]);
	}

	public async Task DeleteAsync(ChatMessageImageId id)
	{
		await _cacheHandler.RemoveByTagAsync(ChatMessageImageCacheUtilities.GetTag(id));
	}

	public async Task DeleteRangeAsync(IEnumerable<ChatMessageImageId> ids)
	{
		await _cacheHandler.RemoveByTagRangeAsync(ChatMessageImageCacheUtilities.GetTagRange(ids));
	}
}
