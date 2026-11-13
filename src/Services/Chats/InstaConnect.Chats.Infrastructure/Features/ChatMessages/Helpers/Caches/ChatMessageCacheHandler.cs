using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Models.Options;
using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Infrastructure.Features.Chats.Utilities;
using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Caches;

internal class ChatMessageCacheHandler : IChatMessageCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly ChatMessageCacheOptions _cacheOptions;

	public ChatMessageCacheHandler(ICacheHandler cacheHandler, ChatMessageCacheOptions cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions;
	}

	public async Task<ChatMessage?> GetByIdAsync(ChatMessageId id, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<ChatMessage>(ChatMessageCacheUtilities.GetByIdKey(id), cancellationToken);
	}

	public async Task<ChatMessageResponse?> GetByIdAsync(ChatMessageId id, CurrentUserQuery currentUser, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<ChatMessageResponse>(ChatMessageCacheUtilities.GetResponseByIdKey(id, currentUser), cancellationToken);
	}

	public async Task AddAsync(ChatMessage entity, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			ChatMessageCacheUtilities.GetByIdKey(entity.Id),
			entity,
			_cacheOptions.Expirations[ChatMessageCacheUtilities.GetByIdKeyPrefix],
			[ChatMessageCacheUtilities.GetTag(entity.Id),
			 ChatCacheUtilities.GetResponseTag(entity.Id.Id)],
			[ChatCacheUtilities.GetTag(entity.Id.Id)],
			cancellationToken);
	}

	public async Task AddAsync(ChatMessageResponse response, CurrentUserQuery currentUser, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			ChatMessageCacheUtilities.GetResponseByIdKey(response.Id, currentUser),
			response,
			_cacheOptions.Expirations[ChatMessageCacheUtilities.GetResponseByIdKeyPrefix],
			[ChatMessageCacheUtilities.GetTag(response.Id),
			 ChatMessageCacheUtilities.GetResponseTag(response.Id),
			 ChatCacheUtilities.GetResponseTag(response.Id.Id)],
			[ChatCacheUtilities.GetTag(response.Id.Id)],
			cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<ChatMessage> entities, CancellationToken cancellationToken)
	{
		foreach (var entity in entities)
		{
			await AddAsync(entity, cancellationToken);
		}
	}

	public async Task<bool?> ExistsByIdAsync(ChatMessageId id, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<bool?>(ChatMessageCacheUtilities.ExistsByIdKey(id), cancellationToken);
	}

	public async Task AddExistsByIdAsync(ChatMessageId id, bool exists, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync<bool?>(
			ChatMessageCacheUtilities.ExistsByIdKey(id),
			exists,
			_cacheOptions.Expirations[ChatMessageCacheUtilities.ExistsByIdKeyPrefix],
			[ChatMessageCacheUtilities.GetTag(id)],
			[ChatCacheUtilities.GetTag(id.Id)],
			cancellationToken);
	}

	public async Task DeleteAsync(ChatMessageId id, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagAsync(ChatMessageCacheUtilities.GetTag(id), cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<ChatMessageId> ids, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagRangeAsync(ChatMessageCacheUtilities.GetTagRange(ids), cancellationToken);
	}

	public async Task DeleteResponseAsync(ChatMessageId id, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagAsync(ChatMessageCacheUtilities.GetResponseTag(id), cancellationToken);
	}

	public async Task DeleteResponseRangeAsync(IEnumerable<ChatMessageId> ids, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagRangeAsync(ChatMessageCacheUtilities.GetResponseTagRange(ids), cancellationToken);
	}
}
