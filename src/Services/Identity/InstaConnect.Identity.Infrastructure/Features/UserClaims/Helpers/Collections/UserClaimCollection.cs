using InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Collections;

internal class UserClaimCollection : IUserClaimCollection
{
	private readonly IUserClaimFluentFactory _fluentFactory;
	private readonly IMongoDbCollectionHandler<UserClaim, UserClaimId> _collectionHandler;

	public UserClaimCollection(
		IUserClaimFluentFactory fluentFactory,
		IMongoDbCollectionHandler<UserClaim, UserClaimId> collectionHandler)
	{
		_fluentFactory = fluentFactory;
		_collectionHandler = collectionHandler;
	}

	public IUserClaimFluent AggregateFluent()
	{
		var fluent = _collectionHandler.AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		UserClaim entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(
		IEnumerable<UserClaim> entities,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertRangeAsync(entities, cancellationToken);
	}

	public async Task DeleteAsync(
		UserClaim entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.RemoveAsync(entity.Id.GetFilter(), cancellationToken);
	}

	public async Task DeleteByParentAsync(
		FilterDefinition<UserClaim> filter,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.RemoveRangeAsync(filter, cancellationToken);
	}
}
