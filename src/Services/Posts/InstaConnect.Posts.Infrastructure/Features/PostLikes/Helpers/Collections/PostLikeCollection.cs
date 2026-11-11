using InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Collections;

internal class PostLikeCollection : MongoDbCollection<PostLike, PostLikeId>, IPostLikeCollection
{
	private readonly IPostCacheHandler _cacheHandler;
	private readonly IPostLikeFluentFactory _fluentFactory;
	private readonly IPostLikeCacheHandler _likeCacheHandler;

	public PostLikeCollection(
		ISessionHandler sessionHandler,
		IPostCacheHandler cacheHandler,
		IPostLikeFluentFactory fluentFactory,
		IMongoCollection<PostLike> collection,
		IPostLikeCacheHandler likeCacheHandler) : base(sessionHandler, collection)
	{
		_cacheHandler = cacheHandler;
		_fluentFactory = fluentFactory;
		_likeCacheHandler = likeCacheHandler;
	}

	public IPostLikeFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task AddAsync(
		PostLike entity,
		CancellationToken cancellationToken)
	{
		await InsertAsync(entity, cancellationToken);
		await _cacheHandler.DeleteResponseAsync(entity.Id.Id);
		await _likeCacheHandler.DeleteAsync(entity.Id);
	}

	public async Task AddByParentAsync(
		FilterDefinition<PostLike> filter,
		CancellationToken cancellationToken)
	{
		var likeIds = await GetIdsAsync(filter, cancellationToken);

		await _cacheHandler.DeleteResponseRangeAsync(likeIds.Select(p => p.Id));
		await _likeCacheHandler.DeleteRangeAsync(likeIds);
	}

	public async Task AddRangeAsync(
		IEnumerable<PostLike> entities,
		CancellationToken cancellationToken)
	{
		await InsertRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteResponseRangeAsync(entities.Select(p => p.Id.Id));
		await _likeCacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}

	public async Task UpdateByParentAsync(
		FilterDefinition<PostLike> filter,
		CancellationToken cancellationToken)
	{
		var likeIds = await GetIdsAsync(filter, cancellationToken);

		await _likeCacheHandler.DeleteRangeAsync(likeIds);
	}

	public async Task DeleteAsync(
		PostLike entity,
		CancellationToken cancellationToken)
	{
		await RemoveAsync(entity.Id.GetFilter(), cancellationToken);
		await _cacheHandler.DeleteResponseAsync(entity.Id.Id);
		await _likeCacheHandler.DeleteAsync(entity.Id);
	}

	public async Task DeleteByParentAsync(
		FilterDefinition<PostLike> filter,
		CancellationToken cancellationToken)
	{
		var likeIds = await GetIdsAsync(filter, cancellationToken);

		await RemoveRangeAsync(filter, cancellationToken);
		await _cacheHandler.DeleteResponseRangeAsync(likeIds.Select(p => p.Id));
		await _likeCacheHandler.DeleteRangeAsync(likeIds);
	}
}
