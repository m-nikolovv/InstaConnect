using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Repositories;

internal class PostCommentLikeCommandRepository : IPostCommentLikeCommandRepository
{
	private readonly IPostCommentLikeCollection _collection;
	private readonly IPostCommentLikeCacheHandler _commentLikeCacheHandler;
	private readonly IPostCommentLikeIncludeBuilderFactory _includeBuilderFactory;

	public PostCommentLikeCommandRepository(
		IPostCommentLikeCollection collection,
		IPostCommentLikeCacheHandler commentLikeCacheHandler,
		IPostCommentLikeIncludeBuilderFactory includeBuilderFactory)
	{
		_collection = collection;
		_includeBuilderFactory = includeBuilderFactory;
		_commentLikeCacheHandler = commentLikeCacheHandler;
	}

	public async Task<PostCommentLike?> GetByIdAsync(
		PostCommentLikeId id,
		PostCommentLikeInclude include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.ApplyIncludes(include)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<PostCommentLike?> GetByIdAsync(
		PostCommentLikeId id,
		CancellationToken cancellationToken)
	{
		var cachedEntity = await _commentLikeCacheHandler.GetByIdAsync(id);

		if (cachedEntity != null)
		{
			return cachedEntity;
		}

		var include = _includeBuilderFactory.Create().Build();

		var entity = await GetByIdAsync(id, include, cancellationToken);

		if (entity != null)
		{
			await _commentLikeCacheHandler.AddAsync(entity);
		}

		return entity;
	}

	public async Task<ICollection<PostCommentLike>> GetByIdRangeAsync(
		IEnumerable<PostCommentLikeId> ids,
		PostCommentLikeInclude include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(ids)
			.ApplyIncludes(include)
			.ToListAsync(cancellationToken);
	}

	public async Task<ICollection<PostCommentLike>> GetByIdRangeAsync(
		IEnumerable<PostCommentLikeId> ids,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().Build();

		return await GetByIdRangeAsync(ids, include, cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		PostCommentLikeId id,
		CancellationToken cancellationToken)
	{
		var cachedExists = await _commentLikeCacheHandler.ExistsByIdAsync(id);

		if (cachedExists != null)
		{
			return cachedExists.Value;
		}

		var exists = await _collection
			.AggregateFluent()
			.Match(id)
			.AnyAsync(cancellationToken);

		await _commentLikeCacheHandler.AddExistsByIdAsync(id, exists);

		return exists;
	}

	public async Task AddAsync(PostCommentLike entity, CancellationToken cancellationToken)
	{
		await _collection.AddAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<PostCommentLike> entities, CancellationToken cancellationToken)
	{
		await _collection.AddRangeAsync(entities, cancellationToken);
	}

	public async Task DeleteAsync(PostCommentLike entity, CancellationToken cancellationToken)
	{
		await _collection.DeleteAsync(entity, cancellationToken);
	}
}
