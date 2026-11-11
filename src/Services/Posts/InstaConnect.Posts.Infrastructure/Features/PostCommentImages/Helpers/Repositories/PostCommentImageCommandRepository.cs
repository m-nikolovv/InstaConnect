using InstaConnect.Posts.Domain.Features.PostCommentImages.Abstractions;
using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Helpers.Repositories;

internal class PostCommentImageCommandRepository : IPostCommentImageCommandRepository
{
	private readonly IPostCommentImageCollection _collection;
	private readonly IPostCommentImageCacheHandler _commentImageCacheHandler;

	public PostCommentImageCommandRepository(
		IPostCommentImageCollection collection,
		IPostCommentImageCacheHandler commentImageCacheHandler)
	{
		_collection = collection;
		_commentImageCacheHandler = commentImageCacheHandler;
	}

	public async Task<PostCommentImage?> GetByIdAsync(
		PostCommentImageId id,
		CancellationToken cancellationToken)
	{
		var cachedEntity = await _commentImageCacheHandler.GetByIdAsync(id);

		if (cachedEntity != null)
		{
			return cachedEntity;
		}

		var entity = await _collection
			.AggregateFluent()
			.Match(id)
			.FirstOrDefaultAsync(cancellationToken);

		if (entity != null)
		{
			await _commentImageCacheHandler.AddAsync(entity);
		}

		return entity;
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
	}

	public async Task AddRangeAsync(IEnumerable<PostCommentImage> entities, CancellationToken cancellationToken)
	{
		await _collection.AddRangeAsync(entities, cancellationToken);
	}

	public async Task DeleteAsync(PostCommentImage entity, CancellationToken cancellationToken)
	{
		await _collection.DeleteAsync(entity, cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<PostCommentImage> entities, CancellationToken cancellationToken)
	{
		await _collection.DeleteRangeAsync(entities, cancellationToken);
	}
}
