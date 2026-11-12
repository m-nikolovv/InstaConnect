using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Abstractions;
using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Models.Entities;
using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Models.ValueObjects;

namespace InstaConnect.Common.Infrastructure.Features.OutboxEvents.Helpers.Collections;

internal class OutboxEventCollection : IOutboxEventCollection
{
	private readonly IMongoDbCollectionHandler<OutboxEvent, OutboxEventId> _collectionHandler;

	public OutboxEventCollection(
		IMongoDbCollectionHandler<OutboxEvent, OutboxEventId> collectionHandler)
	{
		_collectionHandler = collectionHandler;
	}

	public async Task AddAsync(
		OutboxEvent entity,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(
		IEnumerable<OutboxEvent> entities,
		CancellationToken cancellationToken)
	{
		await _collectionHandler.InsertRangeAsync(entities, cancellationToken);
	}
}
