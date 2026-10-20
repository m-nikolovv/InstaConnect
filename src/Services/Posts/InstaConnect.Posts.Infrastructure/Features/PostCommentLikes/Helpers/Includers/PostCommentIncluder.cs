namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Includers;

internal class PostCommentIncluder : IPostCommentLikeIncluder
{
	private readonly IMongoCollection<PostComment> _collection;

	public PostCommentIncluder(IMongoCollection<PostComment> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.PostCommentLike;

	public PostsIncludeType IncludeType => PostsIncludeType.PostComment;

	public IAggregateFluent<PostCommentLike> Include(IAggregateFluent<PostCommentLike> aggregate)
	{
		return aggregate
			.IncludeOne(
				_collection,
				pcl => pcl.Id.CommentId,
				pc => pc.Id,
				pcl => pcl.PostComment!
			);
	}
}
