using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Models.Entities;

namespace InstaConnect.Common.Infrastructure.Features.OutboxEvents.Abstractions;

public interface IOutboxEventCollection : IMongoDbCollection<OutboxEvent>;
