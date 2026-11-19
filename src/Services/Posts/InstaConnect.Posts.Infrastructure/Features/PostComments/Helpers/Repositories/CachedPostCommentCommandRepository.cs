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
		return await _repository.GetByIdAsync(id, cancellationToken);
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
		return await _repository.ExistsByIdAsync(id, cancellationToken);
	}

	public async Task AddAsync(PostComment entity, CancellationToken cancellationToken)
	{
		await _repository.AddAsync(entity, cancellationToken);
		await _cacheHandler.DeleteResponseAsync(entity.Id.Id, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<PostComment> entities, CancellationToken cancellationToken)
	{
		await _repository.AddRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteResponseRangeAsync(entities.Select(p => p.Id.Id), cancellationToken);
	}

	public async Task UpdateAsync(PostComment entity, CancellationToken cancellationToken)
	{
		await _repository.UpdateAsync(entity, cancellationToken);
		await _commentCacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}

	public async Task DeleteAsync(PostComment entity, CancellationToken cancellationToken)
	{
		await _repository.DeleteAsync(entity, cancellationToken);
		await _cacheHandler.DeleteResponseAsync(entity.Id.Id, cancellationToken);
		await _commentCacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}
}
