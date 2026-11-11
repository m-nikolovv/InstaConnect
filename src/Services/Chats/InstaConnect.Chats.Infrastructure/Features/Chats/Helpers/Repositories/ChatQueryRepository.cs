using InstaConnect.Chats.Domain.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Repositories;

internal class ChatQueryRepository : IChatQueryRepository
{
	private readonly IChatCollection _collection;
	private readonly IChatCacheHandler _cacheHandler;
	private readonly IChatIncludeBuilderFactory _includeBuilderFactory;

	public ChatQueryRepository(
		IChatCollection collection,
		IChatCacheHandler cacheHandler,
		IChatIncludeBuilderFactory includeBuilderFactory)
	{
		_collection = collection;
		_cacheHandler = cacheHandler;
		_includeBuilderFactory = includeBuilderFactory;
	}

	public async Task<ICollection<ChatResponse>> GetAllAsync(
		ChatsFilterQuery filter,
		ChatsSortingQuery sorting,
		ChatsPaginationQuery pagination,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithChatMessages().Build();

		return await _collection
			.AggregateFluent()
			.Match(filter)
			.ApplyIncludes(include)
			.ProjectToResponseWithoutParticipantOne(currentUser)
			.ApplySorting(sorting)
			.ApplyPagination(pagination)
			.ToListAsync(cancellationToken);
	}

	public async Task<long> GetTotalCountAsync(
		ChatsFilterQuery filter,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(filter)
			.GetCountAsync(cancellationToken);
	}

	public async Task<ChatResponse?> GetByIdAsync(
		ChatId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var cachedResponse = await _cacheHandler.GetByIdAsync(id, currentUser);

		if (cachedResponse != null)
		{
			return cachedResponse;
		}

		var include = _includeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().WithChatMessages().Build();

		var response = await _collection
			.AggregateFluent()
			.Match(id)
			.ApplyIncludes(include)
			.ProjectToFullResponse(currentUser)
			.FirstOrDefaultAsync(cancellationToken);

		if (response != null)
		{
			await _cacheHandler.AddAsync(response, currentUser);
		}

		return response;
	}

	public async Task<bool> ExistsByIdAsync(
		ChatId id,
		CancellationToken cancellationToken)
	{
		var cachedExists = await _cacheHandler.ExistsByIdAsync(id);

		if (cachedExists != null)
		{
			return cachedExists.Value;
		}

		var exists = await _collection
			.AggregateFluent()
			.Match(id)
			.AnyAsync(cancellationToken);

		await _cacheHandler.AddExistsByIdAsync(id, exists);

		return exists;
	}
}
