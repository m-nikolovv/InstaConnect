using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Repositories;

internal class PostCommentCommandRepository : IPostCommentCommandRepository
{
	private readonly IPostCommentCollection _collection;
	private readonly IPostCommentIncludeBuilderFactory _includeBuilderFactory;

	public PostCommentCommandRepository(
		IPostCommentCollection collection,
		IPostCommentIncludeBuilderFactory includeBuilderFactory)
	{
		_collection = collection;
		_includeBuilderFactory = includeBuilderFactory;
	}

	public async Task<PostComment?> GetByIdAsync(
		PostCommentId id,
		PostCommentInclude include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.Include(include)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<PostComment?> GetByIdAsync(
		PostCommentId id,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().Build();

		return await GetByIdAsync(id, include, cancellationToken);
	}

	public async Task<ICollection<PostComment>> GetByIdRangeAsync(
		IEnumerable<PostCommentId> ids,
		PostCommentInclude include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(ids)
			.Include(include)
			.ToListAsync(cancellationToken);
	}

	public async Task<ICollection<PostComment>> GetByIdRangeAsync(
		IEnumerable<PostCommentId> ids,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().Build();

		return await GetByIdRangeAsync(ids, include, cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		PostCommentId id,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.AnyAsync(cancellationToken);
	}

	public async Task AddAsync(PostComment entity, CancellationToken cancellationToken)
	{
		await _collection.AddAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<PostComment> entities, CancellationToken cancellationToken)
	{
		await _collection.AddRangeAsync(entities, cancellationToken);
	}

	public async Task UpdateAsync(PostComment entity, CancellationToken cancellationToken)
	{
		await _collection.UpdateAsync(entity, cancellationToken);
	}

	public async Task DeleteAsync(PostComment entity, CancellationToken cancellationToken)
	{
		await _collection.DeleteAsync(entity, cancellationToken);
	}
}
