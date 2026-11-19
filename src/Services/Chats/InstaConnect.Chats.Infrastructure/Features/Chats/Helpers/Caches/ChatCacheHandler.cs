using InstaConnect.Chats.Infrastructure.Features.Chats.Models.Options;
using InstaConnect.Chats.Infrastructure.Features.Chats.Utilities;
using InstaConnect.Chats.Infrastructure.Features.Users.Utilities;
using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Caches;

internal class ChatCacheHandler : IChatCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly ChatCacheOptions _cacheOptions;

	public ChatCacheHandler(ICacheHandler cacheHandler, ChatCacheOptions cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions;
	}

	public async Task<ChatResponse?> GetByIdAsync(ChatId id, UserId currentUserId, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<ChatResponse>(ChatCacheUtilities.GetResponseByIdKey(id, currentUserId), cancellationToken);
	}

	public async Task AddAsync(ChatResponse response, UserId currentUserId, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			ChatCacheUtilities.GetResponseByIdKey(response.Id, currentUserId),
			response,
			_cacheOptions.Expirations[ChatCacheUtilities.GetResponseByIdKeyPrefix],
			[ChatCacheUtilities.GetTag(response.Id),
			 ChatCacheUtilities.GetResponseTag(response.Id)],
			[UserCacheUtilities.GetTag(response.Id.ParticipantOneId),
			 UserCacheUtilities.GetTag(response.Id.ParticipantTwoId)],
			cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<ChatResponse> responses, UserId currentUserId, CancellationToken cancellationToken)
	{
		foreach (var response in responses)
		{
			await AddAsync(response, currentUserId, cancellationToken);
		}
	}

	public async Task DeleteAsync(ChatId id, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagAsync(ChatCacheUtilities.GetTag(id), cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<ChatId> ids, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagRangeAsync(ChatCacheUtilities.GetTagRange(ids), cancellationToken);
	}

	public async Task DeleteResponseAsync(ChatId id, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagAsync(ChatCacheUtilities.GetResponseTag(id), cancellationToken);
	}

	public async Task DeleteResponseRangeAsync(IEnumerable<ChatId> ids, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagRangeAsync(ChatCacheUtilities.GetResponseTagRange(ids), cancellationToken);
	}
}
