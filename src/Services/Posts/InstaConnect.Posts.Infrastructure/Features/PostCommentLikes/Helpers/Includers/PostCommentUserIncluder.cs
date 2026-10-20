namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Includers;

internal class PostCommentUserIncluder : IPostCommentLikeIncluder
{
	private readonly IMongoCollection<User> _collection;

	public PostCommentUserIncluder(IMongoCollection<User> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.PostComment;

	public PostsIncludeType IncludeType => PostsIncludeType.User;

	public IAggregateFluent<PostCommentLike> Include(IAggregateFluent<PostCommentLike> aggregate)
	{
		return aggregate
			.IncludeOne(
				_collection,
				pcl => pcl.PostComment!.UserId,
				p => p.Id,
				pcl => pcl.PostComment!.User!
			);
	}
}
