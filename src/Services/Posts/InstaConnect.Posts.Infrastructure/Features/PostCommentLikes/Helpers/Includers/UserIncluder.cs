namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Includers;

internal class UserIncluder : IPostCommentLikeIncluder
{
	private readonly IMongoCollection<User> _collection;

	public UserIncluder(IMongoCollection<User> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.PostCommentLike;

	public PostsIncludeType IncludeType => PostsIncludeType.User;

	public IAggregateFluent<PostCommentLike> Include(IAggregateFluent<PostCommentLike> aggregate)
	{
		return aggregate
			.IncludeOne(
				_collection,
				pcl => pcl.Id.UserId,
				u => u.Id,
				pcl => pcl.User!
			);
	}
}
