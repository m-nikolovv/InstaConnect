using InstaConnect.Common.Infrastructure.Features.Databases.Extensions;
using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Models.Entities;

namespace InstaConnect.Common.Infrastructure.Features.OutboxEvents.Helpers.Collections;

internal class OutboxEventCollectionInitializer : MongoDbCollectionInitializer<OutboxEvent>
{
	public OutboxEventCollectionInitializer(IMongoCollection<OutboxEvent> collection)
		: base(
			collection,
			[
				Builders<OutboxEvent>.IndexKeys.Ascending(c => c.ExpiresAtUtc).ExpireAt()
			])
	{
	}
}
