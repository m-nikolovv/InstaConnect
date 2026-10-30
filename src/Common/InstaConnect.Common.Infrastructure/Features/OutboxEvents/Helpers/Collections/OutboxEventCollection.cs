using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Abstractions;
using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Models.Entities;

namespace InstaConnect.Common.Infrastructure.Features.OutboxEvents.Helpers.Collections;

internal class OutboxEventCollection : MongoDbCollection<OutboxEvent>, IOutboxEventCollection
{
	public OutboxEventCollection(
		ISessionHandler sessionHandler,
		IMongoCollection<OutboxEvent> collection) : base(sessionHandler, collection)
	{
	}
}
