using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Repositories;

internal class UserClaimCommandRepository : IUserClaimCommandRepository
{
	private readonly IUserClaimCollection _collection;
	private readonly IUserClaimCacheHandler _cacheHandler;
	private readonly IUserClaimIncludeBuilderFactory _includeBuilderFactory;

	public UserClaimCommandRepository(
		IUserClaimCollection collection,
		IUserClaimCacheHandler cacheHandler,
		IUserClaimIncludeBuilderFactory includeBuilderFactory)
	{
		_collection = collection;
		_cacheHandler = cacheHandler;
		_includeBuilderFactory = includeBuilderFactory;
	}

	public async Task<UserClaim?> GetByIdAsync(
		UserClaimId id,
		UserClaimInclude include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.ApplyIncludes(include)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<UserClaim?> GetByIdAsync(
		UserClaimId id,
		CancellationToken cancellationToken)
	{
		var cachedEntity = await _cacheHandler.GetByIdAsync(id);

		if (cachedEntity != null)
		{
			return cachedEntity;
		}

		var include = _includeBuilderFactory.Create().Build();

		var entity = await GetByIdAsync(id, include, cancellationToken);

		if (entity != null)
		{
			await _cacheHandler.AddAsync(entity);
		}

		return entity;
	}

	public async Task<ICollection<UserClaim>> GetByIdRangeAsync(
		IEnumerable<UserClaimId> ids,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(ids)
			.ToListAsync(cancellationToken);
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
