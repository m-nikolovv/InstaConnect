namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Includers;

internal class PostPostLikesIncluder : IPostLikeIncluder
{
	private readonly IMongoCollection<PostLike> _collection;

	public PostPostLikesIncluder(IMongoCollection<PostLike> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.Post;

	public PostsIncludeType IncludeType => PostsIncludeType.PostLike;

	public IAggregateFluent<PostLike> Include(IAggregateFluent<PostLike> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.Post!.Id,
				l => l.Id.Id,
				p => p.Post!.PostLikes
			);
	}
}
