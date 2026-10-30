using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Models.Entities;

namespace InstaConnect.Common.Infrastructure.Features.OutboxEvents.Abstractions;

public interface IOutboxEventCommandRepository
{
	public Task AddAsync(OutboxEvent entity, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<OutboxEvent> entities, CancellationToken cancellationToken);
}
