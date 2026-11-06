using InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Collections;

internal class PostCollection : MongoDbCollection<Post, PostId>, IPostCollection
{
	private readonly IPostFluentFactory _fluentFactory;
	private readonly IPostLikeCollection _likeCollection;
	private readonly IPostImageCollection _imageCollection;
	private readonly IPostCommentCollection _commentCollection;

	public PostCollection(
		ISessionHandler sessionHandler,
		IPostFluentFactory fluentFactory,
		IMongoCollection<Post> collection,
		IPostLikeCollection likeCollection,
		IPostImageCollection imageCollection,
		IPostCommentCollection commentCollection) : base(sessionHandler, collection)
	{
		_fluentFactory = fluentFactory;
		_likeCollection = likeCollection;
		_imageCollection = imageCollection;
		_commentCollection = commentCollection;
	}

	public IPostFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task UpdateAsync(
			Post entity,
			CancellationToken cancellationToken)
	{
		await UpdateAsync(entity.Id.GetFilter(), entity, cancellationToken);
	}

	public async Task DeleteAsync(
		Post entity,
		CancellationToken cancellationToken)
	{
		await CascadeDeleteAsync(entity.Id.GetFilter(), cancellationToken);
	}

	public async Task CascadeDeleteAsync(
		FilterDefinition<Post> filter,
		CancellationToken cancellationToken)
	{
		var postIds = await GetIdsAsync(filter, cancellationToken);

		await _imageCollection.CascadeDeleteAsync(postIds.GetPostImageCascadeFilter(), cancellationToken);
		await _likeCollection.CascadeDeleteAsync(postIds.GetPostLikeCascadeFilter(), cancellationToken);
		await _commentCollection.CascadeDeleteAsync(postIds.GetPostCommentCascadeFilter(), cancellationToken);
		await DeleteRangeAsync(filter, cancellationToken);
	}
}
