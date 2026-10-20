namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Includers;

internal class PostCommentPostPostLikesIncluder : IPostCommentLikeIncluder
{
	private readonly IMongoCollection<PostLike> _collection;

	public PostCommentPostPostLikesIncluder(IMongoCollection<PostLike> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.Post;

	public PostsIncludeType IncludeType => PostsIncludeType.PostLike;

	public IAggregateFluent<PostCommentLike> Include(IAggregateFluent<PostCommentLike> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.PostComment!.Post!.Id,
				l => l.Id.Id,
				p => p.PostComment!.Post!.PostLikes
			);
	}
}
