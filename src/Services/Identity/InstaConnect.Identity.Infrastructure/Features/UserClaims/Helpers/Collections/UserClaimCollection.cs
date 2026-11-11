using InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Collections;

internal class UserClaimCollection : MongoDbCollection<UserClaim, UserClaimId>, IUserClaimCollection
{
	private readonly IUserClaimCacheHandler _cacheHandler;
	private readonly IUserClaimFluentFactory _fluentFactory;

	public UserClaimCollection(
		ISessionHandler sessionHandler,
		IUserClaimCacheHandler cacheHandler,
		IUserClaimFluentFactory fluentFactory,
		IMongoCollection<UserClaim> collection) : base(sessionHandler, collection)
	{
		_cacheHandler = cacheHandler;
		_fluentFactory = fluentFactory;
	}

	public IUserClaimFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		UserClaim entity,
		CancellationToken cancellationToken)
	{
		await InsertAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task CascadeAddAsync(
		FilterDefinition<UserClaim> filter,
		CancellationToken cancellationToken)
	{
		await CascadeUpdateAsync(filter, cancellationToken);
	}

	public async Task AddRangeAsync(
		IEnumerable<UserClaim> entities,
		CancellationToken cancellationToken)
	{
		await InsertRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}

	public async Task CascadeUpdateAsync(
		FilterDefinition<UserClaim> filter,
		CancellationToken cancellationToken)
	{
		var claimIds = await GetIdsAsync(filter, cancellationToken);

		await _cacheHandler.DeleteRangeAsync(claimIds);
	}

	public async Task DeleteAsync(
		UserClaim entity,
		CancellationToken cancellationToken)
	{
		await RemoveAsync(entity.Id.GetFilter(), cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task CascadeDeleteAsync(
		FilterDefinition<UserClaim> filter,
		CancellationToken cancellationToken)
	{
		var claimIds = await GetIdsAsync(filter, cancellationToken);

		await RemoveRangeAsync(filter, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(claimIds);
	}
}
