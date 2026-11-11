using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Repositories;

internal class CachedChatMessageQueryRepository : IChatMessageQueryRepository
{
	private readonly IChatMessageQueryRepository _repository;
	private readonly IChatMessageCacheHandler _messageCacheHandler;

	public CachedChatMessageQueryRepository(
		IChatMessageQueryRepository repository,
		IChatMessageCacheHandler messageCacheHandler)
	{
		_repository = repository;
		_messageCacheHandler = messageCacheHandler;
	}

	public async Task<ICollection<ChatMessageResponse>> GetAllAsync(
		ChatMessagesFilterQuery filter,
		ChatMessagesSortingQuery sorting,
		ChatMessagesPaginationQuery pagination,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		return await _repository.GetAllAsync(filter, sorting, pagination, currentUser, cancellationToken);
	}

	public async Task<long> GetTotalCountAsync(
		ChatMessagesFilterQuery filter,
		CancellationToken cancellationToken)
	{
		return await _repository.GetTotalCountAsync(filter, cancellationToken);
	}

	public async Task<ChatMessageResponse?> GetByIdAsync(
		ChatMessageId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var cachedResponse = await _messageCacheHandler.GetByIdAsync(id, currentUser);

		if (cachedResponse != null)
		{
			return cachedResponse;
		}

		var response = await _repository.GetByIdAsync(id, currentUser, cancellationToken);

		if (response != null)
		{
			await _messageCacheHandler.AddAsync(response, currentUser);
		}

		return response;
	}

	public async Task<bool> ExistsByIdAsync(
		ChatMessageId id,
		CancellationToken cancellationToken)
	{
		var cachedExists = await _messageCacheHandler.ExistsByIdAsync(id);

		if (cachedExists != null)
		{
			return cachedExists.Value;
		}

		var exists = await _repository.ExistsByIdAsync(id, cancellationToken);

		await _messageCacheHandler.AddExistsByIdAsync(id, exists);

		return exists;
	}
}
