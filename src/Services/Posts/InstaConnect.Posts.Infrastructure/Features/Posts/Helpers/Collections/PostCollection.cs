using InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Collections;

internal class PostCollection : IPostCollection
{
	private readonly IPostFluentFactory _fluentFactory;
	private readonly IPostLikeCollection _likeCollection;
	private readonly IPostImageCollection _imageCollection;
	private readonly IPostCommentCollection _commentCollection;
	private readonly IMongoDbCollectionHandler<Post, PostId> _collectionHandler;

	public PostCollection(
		IPostFluentFactory fluentFactory,
		IPostLikeCollection likeCollection,
		IPostImageCollection imageCollection,
		IPostCommentCollection commentCollection,
		IMongoDbCollectionHandler<Post, PostId> collectionHandler)
	{
		_fluentFactory = fluentFactory;
		_likeCollection = likeCollection;
		_imageCollection = imageCollection;
		_commentCollection = commentCollection;
		_collectionHandler = collectionHandler;
	}

	public IPostFluent AggregateFluent()
	{
		var fluent = _collectionHandler.AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		Post entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(
		IEnumerable<Post> entities,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertRangeAsync(entities, cancellationToken);
	}

	public async Task UpdateAsync(
		Post entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.ReplaceAsync(entity.Id.GetFilter(), entity, cancellationToken);
	}

	public async Task DeleteAsync(
		Post entity,
		CancellationToken cancellationToken)
	{
		await _imageCollection.DeleteByParentAsync(entity.Id.GetPostImageByParentFilter(), cancellationToken);
		await _likeCollection.DeleteByParentAsync(entity.Id.GetPostLikeByParentFilter(), cancellationToken);
		await _commentCollection.DeleteByParentAsync(entity.Id.GetPostCommentByParentFilter(), cancellationToken);
		await _collectionHandler.RemoveAsync(entity.Id.GetFilter(), cancellationToken);
	}

	public async Task DeleteByParentAsync(
		FilterDefinition<Post> filter,
		CancellationToken cancellationToken)
	{
		var postIds = await AggregateFluent()
			.Match(filter)
			.GetIdsAsync(cancellationToken);

		await _imageCollection.DeleteByParentAsync(postIds.GetPostImageByParentFilter(), cancellationToken);
		await _likeCollection.DeleteByParentAsync(postIds.GetPostLikeByParentFilter(), cancellationToken);
		await _commentCollection.DeleteByParentAsync(postIds.GetPostCommentByParentFilter(), cancellationToken);
		await _collectionHandler.RemoveRangeAsync(filter, cancellationToken);
	}
}
