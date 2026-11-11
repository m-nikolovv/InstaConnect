using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Collections;

internal class PostCommentCollection : MongoDbCollection<PostComment, PostCommentId>, IPostCommentCollection
{
	private readonly IPostCacheHandler _cacheHandler;
	private readonly IPostCommentFluentFactory _fluentFactory;
	private readonly IPostCommentCacheHandler _commentCacheHandler;
	private readonly IPostCommentLikeCollection _commentLikeCollection;
	private readonly IPostCommentImageCollection _commentImageCollection;

	public PostCommentCollection(
		ISessionHandler sessionHandler,
		IPostCacheHandler cacheHandler,
		IPostCommentFluentFactory fluentFactory,
		IMongoCollection<PostComment> collection,
		IPostCommentCacheHandler commentCacheHandler,
		IPostCommentLikeCollection commentLikeCollection,
		IPostCommentImageCollection commentImageCollection) : base(sessionHandler, collection)
	{
		_cacheHandler = cacheHandler;
		_fluentFactory = fluentFactory;
		_commentCacheHandler = commentCacheHandler;
		_commentLikeCollection = commentLikeCollection;
		_commentImageCollection = commentImageCollection;
	}

	public IPostCommentFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		PostComment entity,
		CancellationToken cancellationToken)
	{
		await _commentImageCollection.AddByParentAsync(entity.Id.GetPostCommentImageByParentFilter(), cancellationToken);
		await _commentLikeCollection.AddByParentAsync(entity.Id.GetPostCommentLikeByParentFilter(), cancellationToken);
		await InsertAsync(entity, cancellationToken);
		await _cacheHandler.DeleteResponseAsync(entity.Id.Id);
		await _commentCacheHandler.DeleteAsync(entity.Id);
	}

	public async Task AddByParentAsync(
		FilterDefinition<PostComment> filter,
		CancellationToken cancellationToken)
	{
		var commentIds = await GetIdsAsync(filter, cancellationToken);

		await _commentImageCollection.AddByParentAsync(commentIds.GetPostCommentImageByParentFilter(), cancellationToken);
		await _commentLikeCollection.AddByParentAsync(commentIds.GetPostCommentLikeByParentFilter(), cancellationToken);
		await _cacheHandler.DeleteResponseRangeAsync(commentIds.Select(p => p.Id));
		await _commentCacheHandler.DeleteRangeAsync(commentIds);
	}

	public async Task AddRangeAsync(
		IEnumerable<PostComment> entities,
		CancellationToken cancellationToken)
	{
		await _commentImageCollection.AddByParentAsync(entities.Select(p => p.Id).GetPostCommentImageByParentFilter(), cancellationToken);
		await _commentLikeCollection.AddByParentAsync(entities.Select(p => p.Id).GetPostCommentLikeByParentFilter(), cancellationToken);
		await InsertRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteResponseRangeAsync(entities.Select(p => p.Id.Id));
		await _commentCacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}

	public async Task UpdateAsync(
		PostComment entity,
		CancellationToken cancellationToken)
	{
		await _commentImageCollection.UpdateByParentAsync(entity.Id.GetPostCommentImageByParentFilter(), cancellationToken);
		await _commentLikeCollection.UpdateByParentAsync(entity.Id.GetPostCommentLikeByParentFilter(), cancellationToken);
		await ReplaceAsync(entity.Id.GetFilter(), entity, cancellationToken);
		await _commentCacheHandler.DeleteAsync(entity.Id);
	}

	public async Task UpdateByParentAsync(
		FilterDefinition<PostComment> filter,
		CancellationToken cancellationToken)
	{
		var commentIds = await GetIdsAsync(filter, cancellationToken);

		await _commentImageCollection.UpdateByParentAsync(commentIds.GetPostCommentImageByParentFilter(), cancellationToken);
		await _commentLikeCollection.UpdateByParentAsync(commentIds.GetPostCommentLikeByParentFilter(), cancellationToken);
		await _commentCacheHandler.DeleteRangeAsync(commentIds);
	}

	public async Task DeleteAsync(
		PostComment entity,
		CancellationToken cancellationToken)
	{
		await _commentImageCollection.DeleteByParentAsync(entity.Id.GetPostCommentImageByParentFilter(), cancellationToken);
		await _commentLikeCollection.DeleteByParentAsync(entity.Id.GetPostCommentLikeByParentFilter(), cancellationToken);
		await RemoveAsync(entity.Id.GetFilter(), cancellationToken);
		await _cacheHandler.DeleteResponseAsync(entity.Id.Id);
		await _commentCacheHandler.DeleteAsync(entity.Id);
	}

	public async Task DeleteByParentAsync(
		FilterDefinition<PostComment> filter,
		CancellationToken cancellationToken)
	{
		var commentIds = await GetIdsAsync(filter, cancellationToken);

		await _commentImageCollection.DeleteByParentAsync(commentIds.GetPostCommentImageByParentFilter(), cancellationToken);
		await _commentLikeCollection.DeleteByParentAsync(commentIds.GetPostCommentLikeByParentFilter(), cancellationToken);
		await RemoveRangeAsync(filter, cancellationToken);
		await _cacheHandler.DeleteResponseRangeAsync(commentIds.Select(p => p.Id));
		await _commentCacheHandler.DeleteRangeAsync(commentIds);
	}
}
