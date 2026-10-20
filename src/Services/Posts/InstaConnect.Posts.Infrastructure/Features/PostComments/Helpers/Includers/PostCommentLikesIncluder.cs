namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Includers;

internal class PostCommentLikesIncluder : IPostCommentIncluder
{
	private readonly IMongoCollection<PostCommentLike> _collection;

	public PostCommentLikesIncluder(IMongoCollection<PostCommentLike> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.PostComment;

	public PostsIncludeType IncludeType => PostsIncludeType.PostCommentLike;

	public IAggregateFluent<PostComment> Include(IAggregateFluent<PostComment> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.Id,
				u => u.Id.CommentId,
				p => p.PostCommentLikes
			);
	}
}
