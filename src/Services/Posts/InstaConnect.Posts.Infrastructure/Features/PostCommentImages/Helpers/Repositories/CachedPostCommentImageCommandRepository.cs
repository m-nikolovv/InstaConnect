using InstaConnect.Posts.Domain.Features.PostCommentImages.Abstractions;
using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Helpers.Repositories;

internal class CachedPostCommentImageCommandRepository : IPostCommentImageCommandRepository
{
	private readonly IPostCommentCacheHandler _commentCacheHandler;
	private readonly IPostCommentImageCommandRepository _repository;
	private readonly IPostCommentImageCacheHandler _commentImageCacheHandler;

	public CachedPostCommentImageCommandRepository(
		IPostCommentCacheHandler commentCacheHandler,
		IPostCommentImageCommandRepository repository,
		IPostCommentImageCacheHandler commentImageCacheHandler)
	{
		_repository = repository;
		_commentCacheHandler = commentCacheHandler;
		_commentImageCacheHandler = commentImageCacheHandler;
	}

	public async Task<PostCommentImage?> GetByIdAsync(
		PostCommentImageId id,
		CancellationToken cancellationToken)
	{
		var cachedEntity = await _commentImageCacheHandler.GetByIdAsync(id, cancellationToken);

		if (cachedEntity != null)
		{
			return cachedEntity;
		}

		var entity = await _repository.GetByIdAsync(id, cancellationToken);

		if (entity != null)
		{
			await _commentImageCacheHandler.AddAsync(entity, cancellationToken);
		}

		return entity;
	}

	public async Task<ICollection<PostCommentImage>> GetByIdRangeAsync(
		IEnumerable<PostCommentImageId> ids,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdRangeAsync(ids, cancellationToken);
	}

	public async Task AddAsync(PostCommentImage entity, CancellationToken cancellationToken)
	{
		await _repository.AddAsync(entity, cancellationToken);
		await _commentCacheHandler.DeleteResponseAsync(entity.Id.Id, cancellationToken);
		await _commentImageCacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<PostCommentImage> entities, CancellationToken cancellationToken)
	{
		await _repository.AddRangeAsync(entities, cancellationToken);
		await _commentCacheHandler.DeleteResponseRangeAsync(entities.Select(p => p.Id.Id), cancellationToken);
		await _commentImageCacheHandler.DeleteRangeAsync(entities.Select(p => p.Id), cancellationToken);
	}

	public async Task DeleteAsync(PostCommentImage entity, CancellationToken cancellationToken)
	{
		await _repository.DeleteAsync(entity, cancellationToken);
		await _commentCacheHandler.DeleteResponseAsync(entity.Id.Id, cancellationToken);
		await _commentImageCacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<PostCommentImage> entities, CancellationToken cancellationToken)
	{
		await _repository.DeleteRangeAsync(entities, cancellationToken);
		await _commentCacheHandler.DeleteResponseRangeAsync(entities.Select(p => p.Id.Id), cancellationToken);
		await _commentImageCacheHandler.DeleteRangeAsync(entities.Select(p => p.Id), cancellationToken);
	}
}
