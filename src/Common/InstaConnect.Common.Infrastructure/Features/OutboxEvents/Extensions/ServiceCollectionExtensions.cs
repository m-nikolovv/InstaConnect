using InstaConnect.Common.Infrastructure.Features.Databases.Extensions;
using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Abstractions;
using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Helpers;
using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Helpers.Collections;
using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Helpers.Repositories;
using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Models.Entities;

using MongoDB.Bson.Serialization;

namespace InstaConnect.Common.Infrastructure.Features.OutboxEvents.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddOutboxEvents()
		{
			const string CollectionName = "outbox_events";

			serviceCollection
				.AddScoped<IOutboxEventFactory, OutboxEventFactory>()
				.AddScoped<IOutboxEventCollection, OutboxEventCollection>()
				.AddScoped<IOutboxEventCommandRepository, OutboxEventCommandRepository>();

			serviceCollection.AddCollection<OutboxEvent>(CollectionName);

			BsonClassMap.TryRegisterClassMap<OutboxEvent>(cm =>
			{
				cm.MapIdMember(c => c.Id);

				cm.MapMember(c => c.Id);
				cm.MapMember(c => c.Topic);
				cm.MapMember(c => c.Key);
				cm.MapMember(c => c.Payload);
				cm.MapMember(c => c.CreatedAtUtc);

				cm.MapCreator(c => new OutboxEvent(
					c.Id,
					c.Topic,
					c.Key,
					c.Payload,
					c.CreatedAtUtc));

				cm.SetIgnoreExtraElements(true);
			});

			return serviceCollection;
		}
	}
}
