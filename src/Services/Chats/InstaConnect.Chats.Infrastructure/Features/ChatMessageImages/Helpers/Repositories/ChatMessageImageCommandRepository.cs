namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Helpers.Repositories;

internal class ChatMessageImageCommandRepository : IChatMessageImageCommandRepository
{
	private readonly IChatMessageImageCollection _collection;

	public ChatMessageImageCommandRepository(IChatMessageImageCollection collection)
	{
		_collection = collection;
	}

	public async Task<ChatMessageImage?> GetByIdAsync(
		ChatMessageImageId id,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<ICollection<ChatMessageImage>> GetByIdRangeAsync(
		IEnumerable<ChatMessageImageId> ids,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(ids)
			.ToListAsync(cancellationToken);
	}

	public async Task AddAsync(ChatMessageImage entity, CancellationToken cancellationToken)
	{
		await _collection.AddAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<ChatMessageImage> entities, CancellationToken cancellationToken)
	{
		await _collection.AddRangeAsync(entities, cancellationToken);
	}

	public async Task DeleteAsync(ChatMessageImage entity, CancellationToken cancellationToken)
	{
		await _collection.DeleteAsync(entity, cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<ChatMessageImage> entities, CancellationToken cancellationToken)
	{
		await _collection.DeleteRangeAsync(entities, cancellationToken);
	}
}
