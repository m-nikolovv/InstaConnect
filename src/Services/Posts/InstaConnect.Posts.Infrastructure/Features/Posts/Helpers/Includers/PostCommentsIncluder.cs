namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Includers;

internal class PostCommentsIncluder : IPostIncluder
{
	private readonly IMongoCollection<PostComment> _collection;

	public PostCommentsIncluder(IMongoCollection<PostComment> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.Post;

	public PostsIncludeType IncludeType => PostsIncludeType.PostComment;

	public IAggregateFluent<Post> Include(IAggregateFluent<Post> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.Id,
				c => c.Id.Id,
				p => p.PostComments
			);
	}
}
