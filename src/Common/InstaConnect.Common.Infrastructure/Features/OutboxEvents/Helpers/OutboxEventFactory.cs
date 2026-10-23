using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Events.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Jsons.Abstractions;
using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Abstractions;
using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Models.Entities;

using MassTransit;

namespace InstaConnect.Common.Infrastructure.Features.OutboxEvents.Helpers;

internal class OutboxEventFactory : IOutboxEventFactory
{
	private readonly IGuidProvider _guidProvider;
	private readonly IJsonConverter _jsonConverter;
	private readonly IDateTimeProvider _dateTimeProvider;
	private readonly IEventKeySelectorProvider _eventKeySelectorProvider;

	public OutboxEventFactory(
		IGuidProvider guidProvider,
		IJsonConverter jsonConverter,
		IDateTimeProvider dateTimeProvider,
		IEventKeySelectorProvider eventKeySelectorProvider)
	{
		_guidProvider = guidProvider;
		_jsonConverter = jsonConverter;
		_dateTimeProvider = dateTimeProvider;
		_eventKeySelectorProvider = eventKeySelectorProvider;
	}

	public OutboxEvent Create<TEvent>(TEvent message)
		where TEvent : class, IEventRequest
	{
		var id = _guidProvider.NewStringGuid();
		var topic = KebabCaseEndpointNameFormatter.Instance.Message<TEvent>();
		var key = _eventKeySelectorProvider.GetKeySelector<TEvent>()(message);
		var payload = _jsonConverter.Serialize(message);
		var utcNow = _dateTimeProvider.GetOffsetUtcNow();
		var outboxEvent = new OutboxEvent(
			new(id),
			topic,
			key,
			payload,
			utcNow);

		return outboxEvent;
	}

	public ICollection<OutboxEvent> CreateRange<TEvent>(ICollection<TEvent> messages)
		where TEvent : class, IEventRequest
	{
		return [.. messages.Select(Create)];
	}
}
