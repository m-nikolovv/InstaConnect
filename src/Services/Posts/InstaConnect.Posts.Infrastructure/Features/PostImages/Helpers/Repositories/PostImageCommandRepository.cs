namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Helpers.Repositories;

internal class PostImageCommandRepository : IPostImageCommandRepository
{
	private readonly IPostImageCollection _collection;

	public PostImageCommandRepository(IPostImageCollection collection)
	{
		_collection = collection;
	}

	public async Task<PostImage?> GetByIdAsync(
		PostImageId id,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<ICollection<PostImage>> GetByIdRangeAsync(
		IEnumerable<PostImageId> ids,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(ids)
			.ToListAsync(cancellationToken);
	}

	public async Task AddAsync(PostImage entity, CancellationToken cancellationToken)
	{
		await _collection.AddAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<PostImage> entities, CancellationToken cancellationToken)
	{
		await _collection.AddRangeAsync(entities, cancellationToken);
	}

	public async Task DeleteAsync(PostImage entity, CancellationToken cancellationToken)
	{
		await _collection.DeleteAsync(entity, cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<PostImage> entities, CancellationToken cancellationToken)
	{
		await _collection.DeleteRangeAsync(entities, cancellationToken);
	}
}
