namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Includers;

internal class PostCommentImagesIncluder : IPostCommentIncluder
{
	private readonly IMongoCollection<PostCommentImage> _collection;

	public PostCommentImagesIncluder(IMongoCollection<PostCommentImage> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.PostComment;

	public PostsIncludeType IncludeType => PostsIncludeType.PostCommentImage;

	public IAggregateFluent<PostComment> Include(IAggregateFluent<PostComment> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.Id,
				i => i.Id.Id,
				p => p.PostCommentImages
			);
	}
}
