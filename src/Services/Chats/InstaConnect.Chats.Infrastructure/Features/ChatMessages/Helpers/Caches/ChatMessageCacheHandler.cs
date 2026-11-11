using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Models.Options;
using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Infrastructure.Features.Chats.Utilities;
using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;

using Microsoft.Extensions.Options;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Caches;

internal class ChatMessageCacheHandler : IChatMessageCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly ChatMessageCacheOptions _cacheOptions;

	public ChatMessageCacheHandler(ICacheHandler cacheHandler, IOptions<ChatMessageCacheOptions> cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions.Value;
	}

	public async Task<ChatMessage?> GetByIdAsync(ChatMessageId id)
	{
		return await _cacheHandler.GetAsync<ChatMessage>(ChatMessageCacheUtilities.GetByIdKey(id));
	}

	public async Task<ChatMessageResponse?> GetByIdAsync(ChatMessageId id, CurrentUserQuery currentUser)
	{
		return await _cacheHandler.GetAsync<ChatMessageResponse>(ChatMessageCacheUtilities.GetResponseByIdKey(id, currentUser));
	}

	public async Task AddAsync(ChatMessage entity)
	{
		await _cacheHandler.SetAsync(
			ChatMessageCacheUtilities.GetByIdKey(entity.Id),
			entity,
			_cacheOptions.Expirations[ChatMessageCacheUtilities.GetByIdKeyPrefix],
			[ChatMessageCacheUtilities.GetTag(entity.Id)]);
	}

	public async Task AddAsync(ChatMessageResponse response, CurrentUserQuery currentUser)
	{
		await _cacheHandler.SetAsync(
			ChatMessageCacheUtilities.GetResponseByIdKey(response.Id, currentUser),
			response,
			_cacheOptions.Expirations[ChatMessageCacheUtilities.GetResponseByIdKeyPrefix],
			[ChatMessageCacheUtilities.GetTag(response.Id),
			 ChatMessageCacheUtilities.GetResponseTag(response.Id),
			 ChatCacheUtilities.GetResponseTag(response.Id.Id)]);
	}

	public async Task AddRangeAsync(IEnumerable<ChatMessage> entities)
	{
		foreach (var entity in entities)
		{
			await AddAsync(entity);
		}
	}

	public async Task<bool?> ExistsByIdAsync(ChatMessageId id)
	{
		return await _cacheHandler.GetAsync<bool?>(ChatMessageCacheUtilities.ExistsByIdKey(id));
	}

	public async Task AddExistsByIdAsync(ChatMessageId id, bool exists)
	{
		await _cacheHandler.SetAsync<bool?>(
			ChatMessageCacheUtilities.ExistsByIdKey(id),
			exists,
			_cacheOptions.Expirations[ChatMessageCacheUtilities.ExistsByIdKeyPrefix],
			[ChatMessageCacheUtilities.GetTag(id)]);
	}

	public async Task DeleteAsync(ChatMessageId id)
	{
		await _cacheHandler.RemoveByTagAsync(ChatMessageCacheUtilities.GetTag(id));
	}

	public async Task DeleteRangeAsync(IEnumerable<ChatMessageId> ids)
	{
		await _cacheHandler.RemoveByTagRangeAsync(ChatMessageCacheUtilities.GetTagRange(ids));
	}

	public async Task DeleteResponseAsync(ChatMessageId id)
	{
		await _cacheHandler.RemoveByTagAsync(ChatMessageCacheUtilities.GetResponseTag(id));
	}

	public async Task DeleteResponseRangeAsync(IEnumerable<ChatMessageId> ids)
	{
		await _cacheHandler.RemoveByTagRangeAsync(ChatMessageCacheUtilities.GetResponseTagRange(ids));
	}
}
