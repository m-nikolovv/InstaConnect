using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Abstractions;
using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Models.Entities;
using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Models.ValueObjects;

namespace InstaConnect.Common.Infrastructure.Features.OutboxEvents.Helpers.Collections;

internal class OutboxEventCollection : MongoDbCollection<OutboxEvent, OutboxEventId>, IOutboxEventCollection
{
	public OutboxEventCollection(
		ISessionHandler sessionHandler,
		IMongoCollection<OutboxEvent> collection) : base(sessionHandler, collection)
	{
	}
}
