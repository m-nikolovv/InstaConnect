namespace InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Includers;

internal class PostsIncluder : IUserIncluder
{
	private readonly IMongoCollection<Post> _collection;

	public PostsIncluder(IMongoCollection<Post> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.User;

	public PostsIncludeType IncludeType => PostsIncludeType.Post;

	public IAggregateFluent<User> Include(IAggregateFluent<User> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.Id,
				l => l.UserId,
				p => p.Posts
			);
	}
}
