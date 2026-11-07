using InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;
using InstaConnect.Follows.Infrastructure.Features.Users.Extensions;

namespace InstaConnect.Follows.Infrastructure.Features.Users.Helpers.Collections;

internal class UserCollection : MongoDbCollection<User, UserId>, IUserCollection
{
	private readonly IUserFluentFactory _fluentFactory;
	private readonly IFollowCollection _followCollection;

	public UserCollection(
		ISessionHandler sessionHandler,
		IUserFluentFactory fluentFactory,
		IMongoCollection<User> collection,
		IFollowCollection followCollection) : base(sessionHandler, collection)
	{
		_fluentFactory = fluentFactory;
		_followCollection = followCollection;
	}

	public IUserFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task UpdateAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await UpdateAsync(entity.Id.GetFilter(), entity, cancellationToken);
	}

	public async Task DeleteAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await _followCollection.CascadeDeleteAsync(entity.Id.GetFollowCascadeFilter(), cancellationToken);
		await DeleteAsync(entity.Id.GetFilter(), cancellationToken);
	}
}
