namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Includers;

internal class UserIncluder : IPostCommentIncluder
{
	private readonly IMongoCollection<User> _collection;

	public UserIncluder(IMongoCollection<User> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.PostComment;

	public PostsIncludeType IncludeType => PostsIncludeType.User;

	public IAggregateFluent<PostComment> Include(IAggregateFluent<PostComment> aggregate)
	{
		return aggregate
			.IncludeOne(
				_collection,
				pc => pc.UserId,
				u => u.Id,
				pc => pc.User!
			);
	}
}
