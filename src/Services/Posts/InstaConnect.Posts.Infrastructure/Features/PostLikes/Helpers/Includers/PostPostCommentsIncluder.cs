namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Includers;

internal class PostPostCommentsIncluder : IPostLikeIncluder
{
	private readonly IMongoCollection<PostComment> _collection;

	public PostPostCommentsIncluder(IMongoCollection<PostComment> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.Post;

	public PostsIncludeType IncludeType => PostsIncludeType.PostComment;

	public IAggregateFluent<PostLike> Include(IAggregateFluent<PostLike> aggregate)
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
