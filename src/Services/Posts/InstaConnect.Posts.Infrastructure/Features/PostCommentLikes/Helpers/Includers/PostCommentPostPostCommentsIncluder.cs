namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Includers;

internal class PostCommentPostPostCommentsIncluder : IPostCommentLikeIncluder
{
	private readonly IMongoCollection<PostComment> _collection;

	public PostCommentPostPostCommentsIncluder(IMongoCollection<PostComment> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.Post;

	public PostsIncludeType IncludeType => PostsIncludeType.PostComment;

	public IAggregateFluent<PostCommentLike> Include(IAggregateFluent<PostCommentLike> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.PostComment!.Post!.Id,
				c => c.Id.Id,
				p => p.PostComment!.Post!.PostComments
			);
	}
}
