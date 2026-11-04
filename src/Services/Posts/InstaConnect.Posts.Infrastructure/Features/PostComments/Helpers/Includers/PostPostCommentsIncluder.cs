namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Includers;

internal class PostPostCommentsIncluder : IPostCommentIncluder
{
	private readonly IMongoCollection<PostComment> _collection;

	public PostPostCommentsIncluder(IMongoCollection<PostComment> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.Post;

	public PostsIncludeType IncludeType => PostsIncludeType.PostComment;

	public IAggregateFluent<PostComment> Include(IAggregateFluent<PostComment> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.Post!.Id,
				c => c.Id.Id,
				p => p.Post!.PostComments
			);
	}
}
