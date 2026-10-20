namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Includers;

internal class FollowingIncluder : IFollowIncluder
{
	private readonly IMongoCollection<User> _collection;

	public FollowingIncluder(IMongoCollection<User> collection)
	{
		_collection = collection;
	}

	public FollowsDestinationType DestinationType => FollowsDestinationType.Follow;

	public FollowsIncludeType IncludeType => FollowsIncludeType.Following;

	public IAggregateFluent<Follow> Include(IAggregateFluent<Follow> aggregate)
	{
		return aggregate
			.IncludeOne(
				_collection,
				p => p.Id.FollowingId,
				u => u.Id,
				p => p.Following!
			);
	}
}
