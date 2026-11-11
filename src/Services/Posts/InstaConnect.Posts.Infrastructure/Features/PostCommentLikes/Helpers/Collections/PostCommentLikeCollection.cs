using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Collections;

internal class PostCommentLikeCollection : MongoDbCollection<PostCommentLike, PostCommentLikeId>, IPostCommentLikeCollection
{
	private readonly IPostCommentLikeFluentFactory _fluentFactory;
	private readonly IPostCommentCacheHandler _commentCacheHandler;
	private readonly IPostCommentLikeCacheHandler _commentLikeCacheHandler;

	public PostCommentLikeCollection(
		ISessionHandler sessionHandler,
		IPostCommentLikeFluentFactory fluentFactory,
		IPostCommentCacheHandler commentCacheHandler,
		IMongoCollection<PostCommentLike> collection,
		IPostCommentLikeCacheHandler commentLikeCacheHandler) : base(sessionHandler, collection)
	{
		_fluentFactory = fluentFactory;
		_commentCacheHandler = commentCacheHandler;
		_commentLikeCacheHandler = commentLikeCacheHandler;
	}

	public IPostCommentLikeFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		PostCommentLike entity,
		CancellationToken cancellationToken)
	{
		await InsertAsync(entity, cancellationToken);
		await _commentCacheHandler.DeleteResponseAsync(entity.Id.CommentId);
		await _commentLikeCacheHandler.DeleteAsync(entity.Id);
	}

	public async Task AddByParentAsync(
		FilterDefinition<PostCommentLike> filter,
		CancellationToken cancellationToken)
	{
		var likeIds = await GetIdsAsync(filter, cancellationToken);

		await _commentCacheHandler.DeleteResponseRangeAsync(likeIds.Select(p => p.CommentId));
		await _commentLikeCacheHandler.DeleteRangeAsync(likeIds);
	}

	public async Task AddRangeAsync(
		IEnumerable<PostCommentLike> entities,
		CancellationToken cancellationToken)
	{
		await InsertRangeAsync(entities, cancellationToken);
		await _commentCacheHandler.DeleteResponseRangeAsync(entities.Select(p => p.Id.CommentId));
		await _commentLikeCacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}

	public async Task UpdateByParentAsync(
		FilterDefinition<PostCommentLike> filter,
		CancellationToken cancellationToken)
	{
		var likeIds = await GetIdsAsync(filter, cancellationToken);

		await _commentLikeCacheHandler.DeleteRangeAsync(likeIds);
	}

	public async Task DeleteAsync(
		PostCommentLike entity,
		CancellationToken cancellationToken)
	{
		await RemoveAsync(entity.Id.GetFilter(), cancellationToken);
		await _commentCacheHandler.DeleteResponseAsync(entity.Id.CommentId);
		await _commentLikeCacheHandler.DeleteAsync(entity.Id);
	}

	public async Task DeleteByParentAsync(
		FilterDefinition<PostCommentLike> filter,
		CancellationToken cancellationToken)
	{
		var likeIds = await GetIdsAsync(filter, cancellationToken);

		await RemoveRangeAsync(filter, cancellationToken);
		await _commentCacheHandler.DeleteResponseRangeAsync(likeIds.Select(p => p.CommentId));
		await _commentLikeCacheHandler.DeleteRangeAsync(likeIds);
	}
}
