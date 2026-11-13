using InstaConnect.Chats.Infrastructure.Features.Chats.Models.Options;
using InstaConnect.Chats.Infrastructure.Features.Chats.Utilities;
using InstaConnect.Chats.Infrastructure.Features.Users.Utilities;
using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;

using Microsoft.Extensions.Options;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Caches;

internal class ChatCacheHandler : IChatCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly ChatCacheOptions _cacheOptions;

	public ChatCacheHandler(ICacheHandler cacheHandler, IOptions<ChatCacheOptions> cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions.Value;
	}

	public async Task<Chat?> GetByIdAsync(ChatId id, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<Chat>(ChatCacheUtilities.GetByIdKey(id), cancellationToken);
	}

	public async Task<ChatResponse?> GetByIdAsync(ChatId id, CurrentUserQuery currentUser, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<ChatResponse>(ChatCacheUtilities.GetResponseByIdKey(id, currentUser), cancellationToken);
	}

	public async Task AddAsync(Chat entity, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			ChatCacheUtilities.GetByIdKey(entity.Id),
			entity,
			_cacheOptions.Expirations[ChatCacheUtilities.GetByIdKeyPrefix],
			[ChatCacheUtilities.GetTag(entity.Id)],
			[UserCacheUtilities.GetTag(entity.Id.ParticipantOneId),
			 UserCacheUtilities.GetTag(entity.Id.ParticipantTwoId)],
			cancellationToken);
	}

	public async Task AddAsync(ChatResponse response, CurrentUserQuery currentUser, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			ChatCacheUtilities.GetResponseByIdKey(response.Id, currentUser),
			response,
			_cacheOptions.Expirations[ChatCacheUtilities.GetResponseByIdKeyPrefix],
			[ChatCacheUtilities.GetTag(response.Id),
			 ChatCacheUtilities.GetResponseTag(response.Id)],
			[UserCacheUtilities.GetTag(response.Id.ParticipantOneId),
			 UserCacheUtilities.GetTag(response.Id.ParticipantTwoId)],
			cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<Chat> entities, CancellationToken cancellationToken)
	{
		foreach (var entity in entities)
		{
			await AddAsync(entity, cancellationToken);
		}
	}

	public async Task<bool?> ExistsByIdAsync(ChatId id, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<bool?>(ChatCacheUtilities.ExistsByIdKey(id), cancellationToken);
	}

	public async Task AddExistsByIdAsync(ChatId id, bool exists, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync<bool?>(
			ChatCacheUtilities.ExistsByIdKey(id),
			exists,
			_cacheOptions.Expirations[ChatCacheUtilities.ExistsByIdKeyPrefix],
			[ChatCacheUtilities.GetTag(id)],
			[UserCacheUtilities.GetTag(id.ParticipantOneId),
			 UserCacheUtilities.GetTag(id.ParticipantTwoId)],
			cancellationToken);
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
