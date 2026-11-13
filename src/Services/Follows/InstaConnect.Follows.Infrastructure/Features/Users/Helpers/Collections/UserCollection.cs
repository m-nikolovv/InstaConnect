using InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;
using InstaConnect.Follows.Infrastructure.Features.Users.Extensions;

namespace InstaConnect.Follows.Infrastructure.Features.Users.Helpers.Collections;

internal class UserCollection : IUserCollection
{
	private readonly IUserFluentFactory _fluentFactory;
	private readonly IFollowCollection _followCollection;
	private readonly IMongoDbCollectionHandler<User, UserId> _collectionHandler;

	public UserCollection(
		IUserFluentFactory fluentFactory,
		IFollowCollection followCollection,
		IMongoDbCollectionHandler<User, UserId> collectionHandler)
	{
		_fluentFactory = fluentFactory;
		_followCollection = followCollection;
		_collectionHandler = collectionHandler;
	}

	public IUserFluent AggregateFluent()
	{
		var fluent = _collectionHandler.AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(
		IEnumerable<User> entities,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertRangeAsync(entities, cancellationToken);
	}

	public async Task UpdateAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.ReplaceAsync(entity.Id.GetFilter(), entity, cancellationToken);
	}

	public async Task DeleteAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _followCollection.DeleteByParentAsync(entity.Id.GetFollowByParentFilter(), cancellationToken);
		await _collectionHandler.RemoveAsync(entity.Id.GetFilter(), cancellationToken);
	}
}
