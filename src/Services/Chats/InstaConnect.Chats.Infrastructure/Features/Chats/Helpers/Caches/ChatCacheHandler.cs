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

	public async Task<Chat?> GetByIdAsync(ChatId id)
	{
		return await _cacheHandler.GetAsync<Chat>(ChatCacheUtilities.GetByIdKey(id));
	}

	public async Task<ChatResponse?> GetByIdAsync(ChatId id, CurrentUserQuery currentUser)
	{
		return await _cacheHandler.GetAsync<ChatResponse>(ChatCacheUtilities.GetResponseByIdKey(id, currentUser));
	}

	public async Task AddAsync(Chat entity)
	{
		await _cacheHandler.SetAsync(
			ChatCacheUtilities.GetByIdKey(entity.Id),
			entity,
			_cacheOptions.Expirations[ChatCacheUtilities.GetByIdKeyPrefix],
			[ChatCacheUtilities.GetTag(entity.Id),
			 UserCacheUtilities.GetTag(entity.Id.ParticipantOneId),
			 UserCacheUtilities.GetTag(entity.Id.ParticipantTwoId)]);
	}

	public async Task AddAsync(ChatResponse response, CurrentUserQuery currentUser)
	{
		await _cacheHandler.SetAsync(
			ChatCacheUtilities.GetResponseByIdKey(response.Id, currentUser),
			response,
			_cacheOptions.Expirations[ChatCacheUtilities.GetResponseByIdKeyPrefix],
			[ChatCacheUtilities.GetTag(response.Id),
			 UserCacheUtilities.GetTag(response.Id.ParticipantOneId),
			 UserCacheUtilities.GetTag(response.Id.ParticipantTwoId)]);
	}

	public async Task<bool?> ExistsByIdAsync(ChatId id)
	{
		return await _cacheHandler.GetAsync<bool?>(ChatCacheUtilities.ExistsByIdKey(id));
	}

	public async Task AddExistsByIdAsync(ChatId id, bool exists)
	{
		await _cacheHandler.SetAsync<bool?>(
			ChatCacheUtilities.ExistsByIdKey(id),
			exists,
			_cacheOptions.Expirations[ChatCacheUtilities.ExistsByIdKeyPrefix],
			[ChatCacheUtilities.GetTag(id),
			 UserCacheUtilities.GetTag(id.ParticipantOneId),
			 UserCacheUtilities.GetTag(id.ParticipantTwoId)]);
	}

	public async Task DeleteAsync(ChatId id)
	{
		await _cacheHandler.RemoveByTagAsync(ChatCacheUtilities.GetTag(id));
	}

	public async Task DeleteRangeAsync(IEnumerable<ChatId> ids)
	{
		await _cacheHandler.RemoveByTagRangeAsync(ChatCacheUtilities.GetTagRange(ids));
	}
}
