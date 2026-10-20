namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Includers;

internal class PostCommentPostIncluder : IPostCommentLikeIncluder
{
	private readonly IMongoCollection<Post> _collection;

	public PostCommentPostIncluder(IMongoCollection<Post> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.PostComment;

	public PostsIncludeType IncludeType => PostsIncludeType.Post;

	public IAggregateFluent<PostCommentLike> Include(IAggregateFluent<PostCommentLike> aggregate)
	{
		return aggregate
			.IncludeOne(
				_collection,
				pcl => pcl.Id.CommentId.Id,
				p => p.Id,
				pcl => pcl.PostComment!.Post!
			);
	}
}
