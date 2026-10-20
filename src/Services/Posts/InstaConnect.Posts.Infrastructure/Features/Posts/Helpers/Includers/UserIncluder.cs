namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Includers;

internal class UserIncluder : IPostIncluder
{
	private readonly IMongoCollection<User> _collection;

	public UserIncluder(IMongoCollection<User> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.Post;

	public PostsIncludeType IncludeType => PostsIncludeType.User;

	public IAggregateFluent<Post> Include(IAggregateFluent<Post> aggregate)
	{
		return aggregate
			.IncludeOne(
				_collection,
				p => p.UserId,
				u => u.Id,
				p => p.User!
			);
	}
}
