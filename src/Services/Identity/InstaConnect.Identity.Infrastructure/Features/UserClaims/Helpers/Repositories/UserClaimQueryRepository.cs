using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Repositories;

internal class UserClaimQueryRepository : IUserClaimQueryRepository
{
	private readonly IUserClaimCollection _collection;
	private readonly IUserClaimIncludeBuilderFactory _includeBuilderFactory;

	public UserClaimQueryRepository(
		IUserClaimCollection collection,
		IUserClaimIncludeBuilderFactory includeBuilderFactory)
	{
		_collection = collection;
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
			.ProjectToResponseWithoutUser(current)
			.ApplySorting(sorting)
			.ApplyPagination(pagination)
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
		var include = _includeBuilderFactory.Create().WithUser().Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(include)
			.Match(id)
			.ProjectToFullResponse(current)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		UserClaimId id,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.AnyAsync(cancellationToken);
	}
}
