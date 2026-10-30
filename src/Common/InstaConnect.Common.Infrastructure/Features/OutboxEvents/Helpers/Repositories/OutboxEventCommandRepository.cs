using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Abstractions;
using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Models.Entities;

namespace InstaConnect.Common.Infrastructure.Features.OutboxEvents.Helpers.Repositories;

internal class OutboxEventCommandRepository : IOutboxEventCommandRepository
{
	private readonly IOutboxEventCollection _collection;

	public OutboxEventCommandRepository(IOutboxEventCollection collection)
	{
		_collection = collection;
	}

	public async Task AddAsync(OutboxEvent entity, CancellationToken cancellationToken)
	{
		await _collection.AddAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<OutboxEvent> entities, CancellationToken cancellationToken)
	{
		await _collection.AddRangeAsync(entities, cancellationToken);
	}
}
