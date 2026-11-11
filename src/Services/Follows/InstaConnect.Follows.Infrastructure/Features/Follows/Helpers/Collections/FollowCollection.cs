using InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Collections;

internal class FollowCollection : MongoDbCollection<Follow, FollowId>, IFollowCollection
{
	private readonly IFollowCacheHandler _cacheHandler;
	private readonly IFollowFluentFactory _fluentFactory;

	public FollowCollection(
		ISessionHandler sessionHandler,
		IFollowCacheHandler cacheHandler,
		IFollowFluentFactory fluentFactory,
		IMongoCollection<Follow> collection) : base(sessionHandler, collection)
	{
		_cacheHandler = cacheHandler;
		_fluentFactory = fluentFactory;
	}

	public IFollowFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		Follow entity,
		CancellationToken cancellationToken)
	{
		await InsertAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task CascadeAddAsync(
		FilterDefinition<Follow> filter,
		CancellationToken cancellationToken)
	{
		await CascadeUpdateAsync(filter, cancellationToken);
	}

	public async Task AddRangeAsync(
		IEnumerable<Follow> entities,
		CancellationToken cancellationToken)
	{
		await InsertRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}

	public async Task CascadeUpdateAsync(
		FilterDefinition<Follow> filter,
		CancellationToken cancellationToken)
	{
		var followIds = await GetIdsAsync(filter, cancellationToken);

		await _cacheHandler.DeleteRangeAsync(followIds);
	}

	public async Task DeleteAsync(
		Follow entity,
		CancellationToken cancellationToken)
	{
		await RemoveAsync(entity.Id.GetFilter(), cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task CascadeDeleteAsync(
		FilterDefinition<Follow> filter,
		CancellationToken cancellationToken)
	{
		var followIds = await GetIdsAsync(filter, cancellationToken);

		await RemoveRangeAsync(filter, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(followIds);
	}
}
