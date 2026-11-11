using InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;
using InstaConnect.Follows.Infrastructure.Features.Users.Extensions;

namespace InstaConnect.Follows.Infrastructure.Features.Users.Helpers.Collections;

internal class UserCollection : MongoDbCollection<User, UserId>, IUserCollection
{
	private readonly IUserCacheHandler _cacheHandler;
	private readonly IUserFluentFactory _fluentFactory;
	private readonly IFollowCollection _followCollection;

	public UserCollection(
		ISessionHandler sessionHandler,
		IUserCacheHandler cacheHandler,
		IUserFluentFactory fluentFactory,
		IMongoCollection<User> collection,
		IFollowCollection followCollection) : base(sessionHandler, collection)
	{
		_cacheHandler = cacheHandler;
		_fluentFactory = fluentFactory;
		_followCollection = followCollection;
	}

	public IUserFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _followCollection.AddByParentAsync(entity.Id.GetFollowByParentFilter(), cancellationToken);
		await InsertAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task AddRangeAsync(
		IEnumerable<User> entities,
		CancellationToken cancellationToken)
	{
		await InsertRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}

	public async Task UpdateAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _followCollection.UpdateByParentAsync(entity.Id.GetFollowByParentFilter(), cancellationToken);
		await ReplaceAsync(entity.Id.GetFilter(), entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task DeleteAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _followCollection.DeleteByParentAsync(entity.Id.GetFollowByParentFilter(), cancellationToken);
		await RemoveAsync(entity.Id.GetFilter(), cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}
}
