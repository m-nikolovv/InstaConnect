namespace InstaConnect.Follows.Infrastructure.Features.Users.Helpers.Includers;

internal class FollowFollowingsIncluder : IUserIncluder
{
	private readonly IMongoCollection<Follow> _collection;

	public FollowFollowingsIncluder(IMongoCollection<Follow> collection)
	{
		_collection = collection;
	}

	public FollowsDestinationType DestinationType => FollowsDestinationType.User;

	public FollowsIncludeType IncludeType => FollowsIncludeType.Following;

	public IAggregateFluent<User> Include(IAggregateFluent<User> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.Id,
				l => l.Id.FollowingId,
				p => p.FollowFollowings
			);
	}
}
