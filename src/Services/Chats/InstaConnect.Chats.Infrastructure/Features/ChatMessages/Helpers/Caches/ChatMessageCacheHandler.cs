using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Models.Options;
using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Infrastructure.Features.Chats.Utilities;
using InstaConnect.Chats.Infrastructure.Features.Users.Utilities;
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
			[ChatMessageCacheUtilities.GetTag(entity.Id),
			 ChatCacheUtilities.GetTag(entity.Id.Id),
			 UserCacheUtilities.GetTag(entity.Id.Id.ParticipantOneId),
			 UserCacheUtilities.GetTag(entity.Id.Id.ParticipantTwoId)]);
	}

	public async Task AddAsync(ChatMessageResponse response, CurrentUserQuery currentUser)
	{
		await _cacheHandler.SetAsync(
			ChatMessageCacheUtilities.GetResponseByIdKey(response.Id, currentUser),
			response,
			_cacheOptions.Expirations[ChatMessageCacheUtilities.GetResponseByIdKeyPrefix],
			[ChatMessageCacheUtilities.GetTag(response.Id),
			 ChatCacheUtilities.GetTag(response.Id.Id),
			 UserCacheUtilities.GetTag(response.Id.Id.ParticipantOneId),
			 UserCacheUtilities.GetTag(response.Id.Id.ParticipantTwoId)]);
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
			[ChatMessageCacheUtilities.GetTag(id),
			 ChatCacheUtilities.GetTag(id.Id),
			 UserCacheUtilities.GetTag(id.Id.ParticipantOneId),
			 UserCacheUtilities.GetTag(id.Id.ParticipantTwoId)]);
	}

	public async Task DeleteAsync(ChatMessageId id)
	{
		await _cacheHandler.RemoveByTagAsync(ChatMessageCacheUtilities.GetTag(id));
	}

	public async Task DeleteRangeAsync(IEnumerable<ChatMessageId> ids)
	{
		await _cacheHandler.RemoveByTagRangeAsync(ChatMessageCacheUtilities.GetTagRange(ids));
	}
}
