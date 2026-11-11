using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Repositories;

internal class UserClaimQueryRepository : IUserClaimQueryRepository
{
	private readonly IUserClaimCollection _collection;
	private readonly IUserClaimCacheHandler _cacheHandler;
	private readonly IUserClaimIncludeBuilderFactory _includeBuilderFactory;

	public UserClaimQueryRepository(
		IUserClaimCollection collection,
		IUserClaimCacheHandler cacheHandler,
		IUserClaimIncludeBuilderFactory includeBuilderFactory)
	{
		_collection = collection;
		_cacheHandler = cacheHandler;
		_includeBuilderFactory = includeBuilderFactory;
	}

	public async Task<ICollection<UserClaimResponse>> GetAllAsync(
		UserClaimsFilterQuery filter,
		UserClaimsSortingQuery sorting,
		UserClaimsPaginationQuery pagination,
		CurrentUserQuery current,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(filter)
			.ApplySorting(sorting)
			.ApplyPagination(pagination)
			.ProjectToResponseWithoutUser(current)
			.ToListAsync(cancellationToken);
	}

	public async Task<long> GetTotalCountAsync(
		UserClaimsFilterQuery filter,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(filter)
			.GetCountAsync(cancellationToken);
	}

	public async Task<UserClaimResponse?> GetByIdAsync(
		UserClaimId id,
		CurrentUserQuery current,
		CancellationToken cancellationToken)
	{
		var cachedResponse = await _cacheHandler.GetByIdAsync(id, current);

		if (cachedResponse != null)
		{
			return cachedResponse;
		}

		var include = _includeBuilderFactory.Create().WithUser().Build();

		var response = await _collection
			.AggregateFluent()
			.Match(id)
			.ApplyIncludes(include)
			.ProjectToFullResponse(current)
			.FirstOrDefaultAsync(cancellationToken);

		if (response != null)
		{
			await _cacheHandler.AddAsync(response, current);
		}

		return response;
	}

	public async Task<bool> ExistsByIdAsync(
		UserClaimId id,
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
