using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Repositories;

internal class CachedPostLikeCommandRepository : IPostLikeCommandRepository
{
	private readonly IPostCacheHandler _cacheHandler;
	private readonly IPostLikeCommandRepository _repository;
	private readonly IPostLikeCacheHandler _likeCacheHandler;

	public CachedPostLikeCommandRepository(
		IPostCacheHandler cacheHandler,
		IPostLikeCommandRepository repository,
		IPostLikeCacheHandler likeCacheHandler)
	{
		_repository = repository;
		_cacheHandler = cacheHandler;
		_likeCacheHandler = likeCacheHandler;
	}

	public async Task<PostLike?> GetByIdAsync(
		PostLikeId id,
		PostLikeInclude include,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdAsync(id, include, cancellationToken);
	}

	public async Task<PostLike?> GetByIdAsync(
		PostLikeId id,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdAsync(id, cancellationToken);
	}

	public async Task<ICollection<PostLike>> GetByIdRangeAsync(
		IEnumerable<PostLikeId> ids,
		PostLikeInclude include,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdRangeAsync(ids, include, cancellationToken);
	}

	public async Task<ICollection<PostLike>> GetByIdRangeAsync(
		IEnumerable<PostLikeId> ids,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdRangeAsync(ids, cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		PostLikeId id,
		CancellationToken cancellationToken)
	{
		return await _repository.ExistsByIdAsync(id, cancellationToken);
	}

	public async Task AddAsync(PostLike entity, CancellationToken cancellationToken)
	{
		await _repository.AddAsync(entity, cancellationToken);
		await _cacheHandler.DeleteResponseAsync(entity.Id.Id, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<PostLike> entities, CancellationToken cancellationToken)
	{
		await _repository.AddRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteResponseRangeAsync(entities.Select(p => p.Id.Id), cancellationToken);
	}

	public async Task DeleteAsync(PostLike entity, CancellationToken cancellationToken)
	{
		await _repository.DeleteAsync(entity, cancellationToken);
		await _cacheHandler.DeleteResponseAsync(entity.Id.Id, cancellationToken);
		await _likeCacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}
}
