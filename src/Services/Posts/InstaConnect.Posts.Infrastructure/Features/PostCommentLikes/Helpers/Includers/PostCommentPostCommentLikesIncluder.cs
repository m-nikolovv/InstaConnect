namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Includers;

internal class PostCommentPostCommentLikesIncluder : IPostCommentLikeIncluder
{
	private readonly IMongoCollection<PostCommentLike> _collection;

	public PostCommentPostCommentLikesIncluder(IMongoCollection<PostCommentLike> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.PostComment;

	public PostsIncludeType IncludeType => PostsIncludeType.PostCommentLike;

	public IAggregateFluent<PostCommentLike> Include(IAggregateFluent<PostCommentLike> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.PostComment!.Id,
				l => l.Id.CommentId,
				p => p.PostComment!.PostCommentLikes
			);
	}
}
