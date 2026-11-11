using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers.Collections;

internal class RefreshTokenCollection : MongoDbCollection<RefreshToken, RefreshTokenId>, IRefreshTokenCollection
{
	private readonly IRefreshTokenCacheHandler _cacheHandler;
	private readonly IRefreshTokenFluentFactory _fluentFactory;

	public RefreshTokenCollection(
		ISessionHandler sessionHandler,
		IRefreshTokenCacheHandler cacheHandler,
		IRefreshTokenFluentFactory fluentFactory,
		IMongoCollection<RefreshToken> collection) : base(sessionHandler, collection)
	{
		_cacheHandler = cacheHandler;
		_fluentFactory = fluentFactory;
	}

	public IRefreshTokenFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		RefreshToken entity,
		CancellationToken cancellationToken)
	{
		await InsertAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task AddByParentAsync(
		FilterDefinition<RefreshToken> filter,
		CancellationToken cancellationToken)
	{
		await UpdateByParentAsync(filter, cancellationToken);
	}

	public async Task AddRangeAsync(
		IEnumerable<RefreshToken> entities,
		CancellationToken cancellationToken)
	{
		await InsertRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}

	public async Task UpdateAsync(
		RefreshToken entity,
		CancellationToken cancellationToken)
	{
		await ReplaceAsync(entity.Id.GetFilter(), entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task UpdateByParentAsync(
		FilterDefinition<RefreshToken> filter,
		CancellationToken cancellationToken)
	{
		var tokenIds = await GetIdsAsync(filter, cancellationToken);

		await _cacheHandler.DeleteRangeAsync(tokenIds);
	}

	public async Task DeleteAsync(
		RefreshToken entity,
		CancellationToken cancellationToken)
	{
		await RemoveAsync(entity.Id.GetFilter(), cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task DeleteByParentAsync(
		FilterDefinition<RefreshToken> filter,
		CancellationToken cancellationToken)
	{
		var tokenIds = await GetIdsAsync(filter, cancellationToken);

		await RemoveRangeAsync(filter, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(tokenIds);
	}
}
