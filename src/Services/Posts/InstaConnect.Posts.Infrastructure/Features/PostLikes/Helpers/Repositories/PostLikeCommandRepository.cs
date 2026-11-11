using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Repositories;

internal class PostLikeCommandRepository : IPostLikeCommandRepository
{
	private readonly IPostLikeCollection _collection;
	private readonly IPostLikeCacheHandler _likeCacheHandler;
	private readonly IPostLikeIncludeBuilderFactory _includeBuilderFactory;

	public PostLikeCommandRepository(
		IPostLikeCollection collection,
		IPostLikeCacheHandler likeCacheHandler,
		IPostLikeIncludeBuilderFactory includeBuilderFactory)
	{
		_collection = collection;
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
			.ApplyIncludes(include)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<PostLike?> GetByIdAsync(
		PostLikeId id,
		CancellationToken cancellationToken)
	{
		var cachedEntity = await _likeCacheHandler.GetByIdAsync(id);

		if (cachedEntity != null)
		{
			return cachedEntity;
		}

		var include = _includeBuilderFactory.Create().Build();

		var entity = await GetByIdAsync(id, include, cancellationToken);

		if (entity != null)
		{
			await _likeCacheHandler.AddAsync(entity);
		}

		return entity;
	}

	public async Task<ICollection<PostLike>> GetByIdRangeAsync(
		IEnumerable<PostLikeId> ids,
		PostLikeInclude include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(ids)
			.ApplyIncludes(include)
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
		var cachedExists = await _likeCacheHandler.ExistsByIdAsync(id);

		if (cachedExists != null)
		{
			return cachedExists.Value;
		}

		var exists = await _collection
			.AggregateFluent()
			.Match(id)
			.AnyAsync(cancellationToken);

		await _likeCacheHandler.AddExistsByIdAsync(id, exists);

		return exists;
	}

	public async Task AddAsync(PostLike entity, CancellationToken cancellationToken)
	{
		await _collection.AddAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<PostLike> entities, CancellationToken cancellationToken)
	{
		await _collection.AddRangeAsync(entities, cancellationToken);
	}

	public async Task DeleteAsync(PostLike entity, CancellationToken cancellationToken)
	{
		await _collection.DeleteAsync(entity, cancellationToken);
	}
}
