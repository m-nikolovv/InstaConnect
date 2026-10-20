namespace InstaConnect.Follows.Infrastructure.Features.Users.Helpers.Includers;

internal class FollowFollowersIncluder : IUserIncluder
{
	private readonly IMongoCollection<Follow> _collection;

	public FollowFollowersIncluder(IMongoCollection<Follow> collection)
	{
		_collection = collection;
	}

	public FollowsDestinationType DestinationType => FollowsDestinationType.User;

	public FollowsIncludeType IncludeType => FollowsIncludeType.Follower;

	public IAggregateFluent<User> Include(IAggregateFluent<User> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.Id,
				l => l.Id.FollowerId,
				p => p.FollowFollowers
			);
	}
}
