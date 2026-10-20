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
		var include = _includeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(include)
			.Match(filter)
			.ProjectToResponseWithoutParticipantOne(currentUser)
			.ApplySorting(sorting)
			.ApplyPagination(pagination)
			.ToListAsync(cancellationToken);
	}

	public async Task<long> GetTotalCountAsync(
		ChatsFilterQuery filter,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(include)
			.Match(filter)
			.GetCountAsync(cancellationToken);
	}

	public async Task<ChatResponse?> GetByIdAsync(
		ChatId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(include)
			.Match(id)
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
