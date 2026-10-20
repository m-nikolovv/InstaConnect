namespace InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Includers;

internal class PostLikesIncluder : IUserIncluder
{
	private readonly IMongoCollection<PostLike> _collection;

	public PostLikesIncluder(IMongoCollection<PostLike> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.User;

	public PostsIncludeType IncludeType => PostsIncludeType.PostLike;

	public IAggregateFluent<User> Include(IAggregateFluent<User> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.Id,
				l => l.Id.UserId,
				p => p.PostLikes
			);
	}
}
