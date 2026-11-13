using InstaConnect.Chats.Domain.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Repositories;

internal class ChatQueryRepository : IChatQueryRepository
{
	private readonly IChatCollection _collection;
	private readonly IChatIncludeBuilderFactory _includeBuilderFactory;

	public ChatQueryRepository(
		IChatCollection collection,
		IChatIncludeBuilderFactory includeBuilderFactory)
	{
		_collection = collection;
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
			.Include(include)
			.ProjectToResponseWithoutParticipantOne(currentUser)
			.Sort(sorting)
			.Paginate(pagination)
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
		var include = _includeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().WithChatMessages().Build();

		return await _collection
			.AggregateFluent()
			.Match(id)
			.Include(include)
			.ProjectToFullResponse(currentUser)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		ChatId id,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.AnyAsync(cancellationToken);
	}
}
