namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Includers;

internal class PostUserIncluder : IPostLikeIncluder
{
	private readonly IMongoCollection<User> _collection;

	public PostUserIncluder(IMongoCollection<User> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.Post;

	public PostsIncludeType IncludeType => PostsIncludeType.User;

	public IAggregateFluent<PostLike> Include(IAggregateFluent<PostLike> aggregate)
	{
		return aggregate
			.IncludeOne(
				_collection,
				pc => pc.Post!.UserId,
				u => u.Id,
				pc => pc.Post!.User!
			);
	}
}
