using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Models;
using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Models.Entities;

using Microsoft.Extensions.Options;

namespace InstaConnect.Common.Infrastructure.Features.OutboxEvents.Helpers.Collections;

internal class OutboxEventCollectionInitializer : MongoDbCollectionInitializer<OutboxEvent>
{
	public OutboxEventCollectionInitializer(
		IMongoCollection<OutboxEvent> collection,
		IOptions<OutboxEventOptions> options)
		: base(
			collection,
			[
				new(Builders<OutboxEvent>.IndexKeys.Ascending(c => c.CreatedAtUtc), new CreateIndexOptions { ExpireAfter = options.Value.ExpireAfter })
			])
	{
	}
}
