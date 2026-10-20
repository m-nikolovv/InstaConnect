namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Includers;

internal class PostCommentPostUserIncluder : IPostCommentLikeIncluder
{
	private readonly IMongoCollection<User> _collection;

	public PostCommentPostUserIncluder(IMongoCollection<User> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.Post;

	public PostsIncludeType IncludeType => PostsIncludeType.User;

	public IAggregateFluent<PostCommentLike> Include(IAggregateFluent<PostCommentLike> aggregate)
	{
		return aggregate
			.IncludeOne(
				_collection,
				pcl => pcl.PostComment!.Post!.UserId,
				p => p.Id,
				pcl => pcl.PostComment!.Post!.User!
			);
	}
}
