using InstaConnect.Posts.Domain.Features.PostCommentImages.Abstractions;
using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Helpers.Repositories;

internal class PostCommentImageCommandRepository : IPostCommentImageCommandRepository
{
	private readonly IPostCommentImageCollection _collection;
	private readonly IPostCommentCacheHandler _commentCacheHandler;
	private readonly IPostCommentImageCacheHandler _commentImageCacheHandler;

	public PostCommentImageCommandRepository(
		IPostCommentImageCollection collection,
		IPostCommentCacheHandler commentCacheHandler,
		IPostCommentImageCacheHandler commentImageCacheHandler)
	{
		_collection = collection;
		_commentCacheHandler = commentCacheHandler;
		_commentImageCacheHandler = commentImageCacheHandler;
	}

	public async Task<PostCommentImage?> GetByIdAsync(
		PostCommentImageId id,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<ICollection<PostCommentImage>> GetByIdRangeAsync(
		IEnumerable<PostCommentImageId> ids,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(ids)
			.ToListAsync(cancellationToken);
	}

	public async Task AddAsync(PostCommentImage entity, CancellationToken cancellationToken)
	{
		await _collection.AddAsync(entity, cancellationToken);
		await _commentCacheHandler.DeleteResponseAsync(entity.Id.Id, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<PostCommentImage> entities, CancellationToken cancellationToken)
	{
		await _collection.AddRangeAsync(entities, cancellationToken);
		await _commentCacheHandler.DeleteResponseRangeAsync(entities.Select(p => p.Id.Id), cancellationToken);
	}

	public async Task DeleteAsync(PostCommentImage entity, CancellationToken cancellationToken)
	{
		await _collection.DeleteAsync(entity, cancellationToken);
		await _commentCacheHandler.DeleteResponseAsync(entity.Id.Id, cancellationToken);
		await _commentImageCacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<PostCommentImage> entities, CancellationToken cancellationToken)
	{
		await _collection.DeleteRangeAsync(entities, cancellationToken);
		await _commentCacheHandler.DeleteResponseRangeAsync(entities.Select(p => p.Id.Id), cancellationToken);
		await _commentImageCacheHandler.DeleteRangeAsync(entities.Select(p => p.Id), cancellationToken);
	}
}
