using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Models.ValueObjects;

namespace InstaConnect.Common.Infrastructure.Features.OutboxEvents.Models.Entities;

public class OutboxEvent : IEntityWithId<OutboxEventId>
{
	private OutboxEvent()
	{
		Id = new(string.Empty);
		Topic = string.Empty;
		Key = string.Empty;
		Payload = string.Empty;
	}

	public OutboxEvent(
		OutboxEventId id,
		string topic,
		string key,
		string payload,
		DateTimeOffset createdAtUtc)
	{
		Id = id;
		Topic = topic;
		Key = key;
		Payload = payload;
		CreatedAtUtc = createdAtUtc;
	}

	public OutboxEventId Id { get; }

	public string Topic { get; }

	public string Key { get; }

	public string Payload { get; }

	public DateTimeOffset CreatedAtUtc { get; }
}
