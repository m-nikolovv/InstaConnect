namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Includers;

internal class FollowerIncluder : IFollowIncluder
{
	private readonly IMongoCollection<User> _collection;

	public FollowerIncluder(IMongoCollection<User> collection)
	{
		_collection = collection;
	}

	public FollowsDestinationType DestinationType => FollowsDestinationType.Follow;

	public FollowsIncludeType IncludeType => FollowsIncludeType.Follower;

	public IAggregateFluent<Follow> Include(IAggregateFluent<Follow> aggregate)
	{
		return aggregate
			.IncludeOne(
				_collection,
				p => p.Id.FollowerId,
				u => u.Id,
				p => p.Follower!
			);
	}
}
