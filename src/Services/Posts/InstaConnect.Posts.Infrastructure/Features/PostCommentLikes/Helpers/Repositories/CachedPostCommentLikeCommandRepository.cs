using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Repositories;

internal class CachedPostCommentLikeCommandRepository : IPostCommentLikeCommandRepository
{
	private readonly IPostCommentLikeCommandRepository _repository;
	private readonly IPostCommentCacheHandler _commentCacheHandler;
	private readonly IPostCommentLikeCacheHandler _commentLikeCacheHandler;

	public CachedPostCommentLikeCommandRepository(
		IPostCommentLikeCommandRepository repository,
		IPostCommentCacheHandler commentCacheHandler,
		IPostCommentLikeCacheHandler commentLikeCacheHandler)
	{
		_repository = repository;
		_commentCacheHandler = commentCacheHandler;
		_commentLikeCacheHandler = commentLikeCacheHandler;
	}

	public async Task<PostCommentLike?> GetByIdAsync(
		PostCommentLikeId id,
		PostCommentLikeInclude include,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdAsync(id, include, cancellationToken);
	}

	public async Task<PostCommentLike?> GetByIdAsync(
		PostCommentLikeId id,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdAsync(id, cancellationToken);
	}

	public async Task<ICollection<PostCommentLike>> GetByIdRangeAsync(
		IEnumerable<PostCommentLikeId> ids,
		PostCommentLikeInclude include,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdRangeAsync(ids, include, cancellationToken);
	}

	public async Task<ICollection<PostCommentLike>> GetByIdRangeAsync(
		IEnumerable<PostCommentLikeId> ids,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdRangeAsync(ids, cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		PostCommentLikeId id,
		CancellationToken cancellationToken)
	{
		return await _repository.ExistsByIdAsync(id, cancellationToken);
	}

	public async Task AddAsync(PostCommentLike entity, CancellationToken cancellationToken)
	{
		await _repository.AddAsync(entity, cancellationToken);
		await _commentCacheHandler.DeleteResponseAsync(entity.Id.CommentId, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<PostCommentLike> entities, CancellationToken cancellationToken)
	{
		await _repository.AddRangeAsync(entities, cancellationToken);
		await _commentCacheHandler.DeleteResponseRangeAsync(entities.Select(p => p.Id.CommentId), cancellationToken);
	}

	public async Task DeleteAsync(PostCommentLike entity, CancellationToken cancellationToken)
	{
		await _repository.DeleteAsync(entity, cancellationToken);
		await _commentCacheHandler.DeleteResponseAsync(entity.Id.CommentId, cancellationToken);
		await _commentLikeCacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}
}
