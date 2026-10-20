namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Includers;

internal class PostPostLikesIncluder : IPostCommentIncluder
{
	private readonly IMongoCollection<PostLike> _collection;

	public PostPostLikesIncluder(IMongoCollection<PostLike> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.Post;

	public PostsIncludeType IncludeType => PostsIncludeType.PostLike;

	public IAggregateFluent<PostComment> Include(IAggregateFluent<PostComment> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.Post!.Id,
				l => l.Id.Id,
				p => p.Post!.PostLikes
			);
	}
}
