namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Includers;

internal class PostPostImagesIncluder : IPostCommentIncluder
{
	private readonly IMongoCollection<PostImage> _collection;

	public PostPostImagesIncluder(IMongoCollection<PostImage> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.Post;

	public PostsIncludeType IncludeType => PostsIncludeType.PostImage;

	public IAggregateFluent<PostComment> Include(IAggregateFluent<PostComment> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.Post!.Id,
				i => i.Id.Id,
				p => p.Post!.PostImages
			);
	}
}
