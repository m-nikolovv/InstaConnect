namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Includers;

internal class UserIncluder : IPostLikeIncluder
{
	private readonly IMongoCollection<User> _collection;

	public UserIncluder(IMongoCollection<User> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.PostLike;

	public PostsIncludeType IncludeType => PostsIncludeType.User;

	public IAggregateFluent<PostLike> Include(IAggregateFluent<PostLike> aggregate)
	{
		return aggregate
			.IncludeOne(
				_collection,
				p => p.Id.UserId,
				u => u.Id,
				p => p.User!
			);
	}
}
