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

	public async Task<ChatMessageResponse?> GetByIdAsync(ChatMessageId id, UserId currentUserId, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<ChatMessageResponse>(ChatMessageCacheUtilities.GetResponseByIdKey(id, currentUserId), cancellationToken);
	}

	public async Task AddAsync(ChatMessageResponse response, UserId currentUserId, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			ChatMessageCacheUtilities.GetResponseByIdKey(response.Id, currentUserId),
			response,
			_cacheOptions.Expirations[ChatMessageCacheUtilities.GetResponseByIdKeyPrefix],
			[ChatMessageCacheUtilities.GetTag(response.Id),
			 ChatMessageCacheUtilities.GetResponseTag(response.Id),
			 ChatCacheUtilities.GetResponseTag(response.Id.Id)],
			[ChatCacheUtilities.GetTag(response.Id.Id)],
			cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<ChatMessageResponse> responses, UserId currentUserId, CancellationToken cancellationToken)
	{
		foreach (var response in responses)
		{
			await AddAsync(response, currentUserId, cancellationToken);
		}
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
