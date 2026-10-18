namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Helpers.Repositories;

internal class PostCommentImageCommandRepository : IPostCommentImageCommandRepository
{
	private readonly IPostCommentImageCollection _collection;

	public PostCommentImageCommandRepository(IPostCommentImageCollection collection)
	{
		_collection = collection;
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
