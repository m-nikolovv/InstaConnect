using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Repositories;

internal class PostLikeCommandRepository : IPostLikeCommandRepository
{
	private readonly IPostLikeCollection _collection;
	private readonly IPostCacheHandler _cacheHandler;
	private readonly IPostLikeCacheHandler _likeCacheHandler;
	private readonly IPostLikeIncludeBuilderFactory _includeBuilderFactory;

	public PostLikeCommandRepository(
		IPostLikeCollection collection,
		IPostCacheHandler cacheHandler,
		IPostLikeCacheHandler likeCacheHandler,
		IPostLikeIncludeBuilderFactory includeBuilderFactory)
	{
		_collection = collection;
		_cacheHandler = cacheHandler;
		_likeCacheHandler = likeCacheHandler;
		_includeBuilderFactory = includeBuilderFactory;
	}

	public async Task<PostLike?> GetByIdAsync(
		PostLikeId id,
		PostLikeInclude include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.Include(include)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<PostLike?> GetByIdAsync(
		PostLikeId id,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().Build();

		return await GetByIdAsync(id, include, cancellationToken);
	}

	public async Task<ICollection<PostLike>> GetByIdRangeAsync(
		IEnumerable<PostLikeId> ids,
		PostLikeInclude include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(ids)
			.Include(include)
			.ToListAsync(cancellationToken);
	}

	public async Task<ICollection<PostLike>> GetByIdRangeAsync(
		IEnumerable<PostLikeId> ids,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().Build();

		return await GetByIdRangeAsync(ids, include, cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		PostLikeId id,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.AnyAsync(cancellationToken);
	}

	public async Task AddAsync(PostLike entity, CancellationToken cancellationToken)
	{
		await _collection.AddAsync(entity, cancellationToken);
		await _cacheHandler.DeleteResponseAsync(entity.Id.Id, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<PostLike> entities, CancellationToken cancellationToken)
	{
		await _collection.AddRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteResponseRangeAsync(entities.Select(p => p.Id.Id), cancellationToken);
	}

	public async Task DeleteAsync(PostLike entity, CancellationToken cancellationToken)
	{
		await _collection.DeleteAsync(entity, cancellationToken);
		await _cacheHandler.DeleteResponseAsync(entity.Id.Id, cancellationToken);
		await _likeCacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}
}
