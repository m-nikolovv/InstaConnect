namespace InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Includers;

internal class PostCommentsIncluder : IUserIncluder
{
	private readonly IMongoCollection<PostComment> _collection;

	public PostCommentsIncluder(IMongoCollection<PostComment> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.User;

	public PostsIncludeType IncludeType => PostsIncludeType.PostComment;

	public IAggregateFluent<User> Include(IAggregateFluent<User> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.Id,
				l => l.UserId,
				p => p.PostComments
			);
	}
}
