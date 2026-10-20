namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Includers;

internal class PostLikesIncluder : IPostIncluder
{
	private readonly IMongoCollection<PostLike> _collection;

	public PostLikesIncluder(IMongoCollection<PostLike> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.Post;

	public PostsIncludeType IncludeType => PostsIncludeType.PostLike;

	public IAggregateFluent<Post> Include(IAggregateFluent<Post> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.Id,
				l => l.Id.Id,
				p => p.PostLikes
			);
	}
}
