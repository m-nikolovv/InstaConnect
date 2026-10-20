namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Includers;

internal class PostIncluder : IPostLikeIncluder
{
	private readonly IMongoCollection<Post> _collection;

	public PostIncluder(IMongoCollection<Post> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.PostLike;

	public PostsIncludeType IncludeType => PostsIncludeType.Post;

	public IAggregateFluent<PostLike> Include(IAggregateFluent<PostLike> aggregate)
	{
		return aggregate
			.IncludeOne(
				_collection,
				pc => pc.Id.Id,
				p => p.Id,
				pc => pc.Post!
			);
	}
}
