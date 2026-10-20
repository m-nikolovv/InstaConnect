namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Includers;

internal class PostIncluder : IPostCommentIncluder
{
	private readonly IMongoCollection<Post> _collection;

	public PostIncluder(IMongoCollection<Post> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.PostComment;

	public PostsIncludeType IncludeType => PostsIncludeType.Post;

	public IAggregateFluent<PostComment> Include(IAggregateFluent<PostComment> aggregate)
	{
		return aggregate
			.IncludeOne(
				_collection,
				pc => pc.Id.Id,
				p => p.Id,
				pc => pc.Post!
			);
	}
}
