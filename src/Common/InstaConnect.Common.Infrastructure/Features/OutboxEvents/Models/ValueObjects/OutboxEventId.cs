namespace InstaConnect.Common.Infrastructure.Features.OutboxEvents.Models.ValueObjects;

public record OutboxEventId(string Id) : IEntityId;
