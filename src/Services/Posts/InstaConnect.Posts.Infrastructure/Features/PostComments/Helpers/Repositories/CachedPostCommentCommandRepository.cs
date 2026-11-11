using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Repositories;

internal class CachedPostCommentCommandRepository : IPostCommentCommandRepository
{
	private readonly IPostCacheHandler _cacheHandler;
	private readonly IPostCommentCommandRepository _repository;
	private readonly IPostCommentCacheHandler _commentCacheHandler;

	public CachedPostCommentCommandRepository(
		IPostCacheHandler cacheHandler,
		IPostCommentCommandRepository repository,
		IPostCommentCacheHandler commentCacheHandler)
	{
		_repository = repository;
		_cacheHandler = cacheHandler;
		_commentCacheHandler = commentCacheHandler;
	}

	public async Task<PostComment?> GetByIdAsync(
		PostCommentId id,
		PostCommentInclude include,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdAsync(id, include, cancellationToken);
	}

	public async Task<PostComment?> GetByIdAsync(
		PostCommentId id,
		CancellationToken cancellationToken)
	{
		var cachedEntity = await _commentCacheHandler.GetByIdAsync(id);

		if (cachedEntity != null)
		{
			return cachedEntity;
		}

		var entity = await _repository.GetByIdAsync(id, cancellationToken);

		if (entity != null)
		{
			await _commentCacheHandler.AddAsync(entity);
		}

		return entity;
	}

	public async Task<ICollection<PostComment>> GetByIdRangeAsync(
		IEnumerable<PostCommentId> ids,
		PostCommentInclude include,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdRangeAsync(ids, include, cancellationToken);
	}

	public async Task<ICollection<PostComment>> GetByIdRangeAsync(
		IEnumerable<PostCommentId> ids,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdRangeAsync(ids, cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		PostCommentId id,
		CancellationToken cancellationToken)
	{
		var cachedExists = await _commentCacheHandler.ExistsByIdAsync(id);

		if (cachedExists != null)
		{
			return cachedExists.Value;
		}

		var exists = await _repository.ExistsByIdAsync(id, cancellationToken);

		await _commentCacheHandler.AddExistsByIdAsync(id, exists);

		return exists;
	}

	public async Task AddAsync(PostComment entity, CancellationToken cancellationToken)
	{
		await _repository.AddAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id.Id);
		await _commentCacheHandler.DeleteAsync(entity.Id);
	}

	public async Task AddRangeAsync(IEnumerable<PostComment> entities, CancellationToken cancellationToken)
	{
		await _repository.AddRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(entities.Select(p => p.Id.Id));
		await _commentCacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}

	public async Task UpdateAsync(PostComment entity, CancellationToken cancellationToken)
	{
		await _repository.UpdateAsync(entity, cancellationToken);
		await _commentCacheHandler.DeleteAsync(entity.Id);
	}

	public async Task DeleteAsync(PostComment entity, CancellationToken cancellationToken)
	{
		await _repository.DeleteAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id.Id);
		await _commentCacheHandler.DeleteAsync(entity.Id);
	}
}
