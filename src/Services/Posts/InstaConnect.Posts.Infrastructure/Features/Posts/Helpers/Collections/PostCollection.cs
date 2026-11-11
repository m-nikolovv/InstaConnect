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
		await _imageCollection.AddByParentAsync(entity.Id.GetPostImageByParentFilter(), cancellationToken);
		await _likeCollection.AddByParentAsync(entity.Id.GetPostLikeByParentFilter(), cancellationToken);
		await _commentCollection.AddByParentAsync(entity.Id.GetPostCommentByParentFilter(), cancellationToken);
		await InsertAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task AddByParentAsync(
		FilterDefinition<Post> filter,
		CancellationToken cancellationToken)
	{
		await UpdateByParentAsync(filter, cancellationToken);
	}

	public async Task AddRangeAsync(
		IEnumerable<Post> entities,
		CancellationToken cancellationToken)
	{
		await _imageCollection.AddByParentAsync(entities.Select(p => p.Id).GetPostImageByParentFilter(), cancellationToken);
		await _likeCollection.AddByParentAsync(entities.Select(p => p.Id).GetPostLikeByParentFilter(), cancellationToken);
		await _commentCollection.AddByParentAsync(entities.Select(p => p.Id).GetPostCommentByParentFilter(), cancellationToken);
		await InsertRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}

	public async Task UpdateAsync(
		Post entity,
		CancellationToken cancellationToken)
	{
		await _imageCollection.UpdateByParentAsync(entity.Id.GetPostImageByParentFilter(), cancellationToken);
		await _likeCollection.UpdateByParentAsync(entity.Id.GetPostLikeByParentFilter(), cancellationToken);
		await _commentCollection.UpdateByParentAsync(entity.Id.GetPostCommentByParentFilter(), cancellationToken);
		await ReplaceAsync(entity.Id.GetFilter(), entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task UpdateByParentAsync(
		FilterDefinition<Post> filter,
		CancellationToken cancellationToken)
	{
		var postIds = await GetIdsAsync(filter, cancellationToken);

		await _imageCollection.UpdateByParentAsync(postIds.GetPostImageByParentFilter(), cancellationToken);
		await _likeCollection.UpdateByParentAsync(postIds.GetPostLikeByParentFilter(), cancellationToken);
		await _commentCollection.UpdateByParentAsync(postIds.GetPostCommentByParentFilter(), cancellationToken);
		await _cacheHandler.DeleteRangeAsync(postIds);
	}

	public async Task DeleteAsync(
		Post entity,
		CancellationToken cancellationToken)
	{
		await _imageCollection.DeleteByParentAsync(entity.Id.GetPostImageByParentFilter(), cancellationToken);
		await _likeCollection.DeleteByParentAsync(entity.Id.GetPostLikeByParentFilter(), cancellationToken);
		await _commentCollection.DeleteByParentAsync(entity.Id.GetPostCommentByParentFilter(), cancellationToken);
		await RemoveAsync(entity.Id.GetFilter(), cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id);
	}

	public async Task DeleteByParentAsync(
		FilterDefinition<Post> filter,
		CancellationToken cancellationToken)
	{
		var postIds = await GetIdsAsync(filter, cancellationToken);

		await _imageCollection.DeleteByParentAsync(postIds.GetPostImageByParentFilter(), cancellationToken);
		await _likeCollection.DeleteByParentAsync(postIds.GetPostLikeByParentFilter(), cancellationToken);
		await _commentCollection.DeleteByParentAsync(postIds.GetPostCommentByParentFilter(), cancellationToken);
		await RemoveRangeAsync(filter, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(postIds);
	}
}
