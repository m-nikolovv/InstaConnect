using InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Collections;

internal class PostCollection : MongoDbCollection<Post, PostId>, IPostCollection
{
	private readonly IPostCacheHandler _cacheHandler;
	private readonly IPostFluentFactory _fluentFactory;
	private readonly IPostLikeCollection _likeCollection;
	private readonly IPostImageCollection _imageCollection;
	private readonly IPostCommentCollection _commentCollection;

	public PostCollection(
		ISessionHandler sessionHandler,
		IPostCacheHandler cacheHandler,
		IPostFluentFactory fluentFactory,
		IMongoCollection<Post> collection,
		IPostLikeCollection likeCollection,
		IPostImageCollection imageCollection,
		IPostCommentCollection commentCollection) : base(sessionHandler, collection)
	{
		_cacheHandler = cacheHandler;
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

	public async Task AddAsync(
		Post entity,
		CancellationToken cancellationToken)
	{
		await _imageCollection.CascadeAddAsync(entity.Id.GetPostImageCascadeFilter(), cancellationToken);
		await _likeCollection.CascadeAddAsync(entity.Id.GetPostLikeCascadeFilter(), cancellationToken);
		await _commentCollection.CascadeAddAsync(entity.Id.GetPostCommentCascadeFilter(), cancellationToken);
		await InsertAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task CascadeAddAsync(
		FilterDefinition<Post> filter,
		CancellationToken cancellationToken)
	{
		await CascadeUpdateAsync(filter, cancellationToken);
	}

	public async Task AddRangeAsync(
		IEnumerable<Post> entities,
		CancellationToken cancellationToken)
	{
		await _imageCollection.CascadeAddAsync(entities.Select(p => p.Id).GetPostImageCascadeFilter(), cancellationToken);
		await _likeCollection.CascadeAddAsync(entities.Select(p => p.Id).GetPostLikeCascadeFilter(), cancellationToken);
		await _commentCollection.CascadeAddAsync(entities.Select(p => p.Id).GetPostCommentCascadeFilter(), cancellationToken);
		await InsertRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}

	public async Task UpdateAsync(
		Post entity,
		CancellationToken cancellationToken)
	{
		await _imageCollection.CascadeUpdateAsync(entity.Id.GetPostImageCascadeFilter(), cancellationToken);
		await _likeCollection.CascadeUpdateAsync(entity.Id.GetPostLikeCascadeFilter(), cancellationToken);
		await _commentCollection.CascadeUpdateAsync(entity.Id.GetPostCommentCascadeFilter(), cancellationToken);
		await ReplaceAsync(entity.Id.GetFilter(), entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task CascadeUpdateAsync(
		FilterDefinition<Post> filter,
		CancellationToken cancellationToken)
	{
		var postIds = await GetIdsAsync(filter, cancellationToken);

		await _imageCollection.CascadeUpdateAsync(postIds.GetPostImageCascadeFilter(), cancellationToken);
		await _likeCollection.CascadeUpdateAsync(postIds.GetPostLikeCascadeFilter(), cancellationToken);
		await _commentCollection.CascadeUpdateAsync(postIds.GetPostCommentCascadeFilter(), cancellationToken);
		await _cacheHandler.DeleteRangeAsync(postIds);
	}

	public async Task DeleteAsync(
		Post entity,
		CancellationToken cancellationToken)
	{
		await _imageCollection.CascadeDeleteAsync(entity.Id.GetPostImageCascadeFilter(), cancellationToken);
		await _likeCollection.CascadeDeleteAsync(entity.Id.GetPostLikeCascadeFilter(), cancellationToken);
		await _commentCollection.CascadeDeleteAsync(entity.Id.GetPostCommentCascadeFilter(), cancellationToken);
		await RemoveAsync(entity.Id.GetFilter(), cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task CascadeDeleteAsync(
		FilterDefinition<Post> filter,
		CancellationToken cancellationToken)
	{
		var postIds = await GetIdsAsync(filter, cancellationToken);

		await _imageCollection.CascadeDeleteAsync(postIds.GetPostImageCascadeFilter(), cancellationToken);
		await _likeCollection.CascadeDeleteAsync(postIds.GetPostLikeCascadeFilter(), cancellationToken);
		await _commentCollection.CascadeDeleteAsync(postIds.GetPostCommentCascadeFilter(), cancellationToken);
		await RemoveRangeAsync(filter, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(postIds);
	}
}
