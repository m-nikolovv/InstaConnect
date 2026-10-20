using InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Collections;

internal class FollowCollection : MongoDbCollection<Follow>, IFollowCollection
{
	private readonly IFollowFluentFactory _fluentFactory;

	public FollowCollection(
		ISessionHandler sessionHandler,
		IFollowFluentFactory fluentFactory,
		IMongoCollection<Follow> collection) : base(sessionHandler, collection)
	{
		_fluentFactory = fluentFactory;
	}

	public IFollowFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task DeleteAsync(
		Follow entity,
		CancellationToken cancellationToken)
	{
		await DeleteAsync(entity.Id.GetFilter(), cancellationToken);
	}
}
