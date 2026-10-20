using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Repositories;

internal class UserClaimCommandRepository : IUserClaimCommandRepository
{
	private readonly IUserClaimCollection _collection;
	private readonly IUserClaimIncludeBuilderFactory _includeBuilderFactory;

	public UserClaimCommandRepository(
		IUserClaimCollection collection,
		IUserClaimIncludeBuilderFactory includeBuilderFactory)
	{
		_collection = collection;
		_includeBuilderFactory = includeBuilderFactory;
	}

	public async Task<UserClaim?> GetByIdAsync(
		UserClaimId id,
		UserClaimInclude include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.ApplyIncludes(include)
			.Match(id)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<UserClaim?> GetByIdAsync(
		UserClaimId id,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().Build();

		return await GetByIdAsync(id, include, cancellationToken);
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

	public async Task AddAsync(UserClaim entity, CancellationToken cancellationToken)
	{
		await _collection.AddAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<UserClaim> entities, CancellationToken cancellationToken)
	{
		await _collection.AddRangeAsync(entities, cancellationToken);
	}

	public async Task DeleteAsync(UserClaim entity, CancellationToken cancellationToken)
	{
		await _collection.DeleteAsync(entity, cancellationToken);
	}
}
